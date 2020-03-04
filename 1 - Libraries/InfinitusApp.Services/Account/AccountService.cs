using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using InfinitusApp.Services;
using InfinitusApp.Services.Application;
using InfinitusApp.Services.Infrastructure;
using Microsoft.WindowsAzure.MobileServices;
using Naylah.Core.Entities;
using Naylah.Identity.Client;
using Naylah.Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InfinitusApp.Core.Data.DataModels.ApplicationUser;

namespace InfinitusApp.Services.Account
{
    public class AccountService : ServiceBase
    {
        public const string CurrentAccountCacheKey = "CurrentUser";

        public AccountService(
            InfinitusAppServiceClient _serviceClient,
            ApplicationService _applicationService,
            ICacheService _cacheService = null
            ) :
            base(_serviceClient)
        {
            ApplicationService = _applicationService;
            CacheService = _cacheService;
        }

        public event EventHandler SelectedAccountChanged;

        public event EventHandler SignedIn;

        public event EventHandler SignedOut;

        public Account CurrentAccount
        {
            get;
            protected set;
        }

        private NaylahIdentityService naylahIdentityService { get { return ServiceClient.IdentityService; } }

        private ICacheService CacheService { get; set; }

        private ApplicationService ApplicationService { get; set; }

        public void RaiseCurrentAccountChanged()
        {
            RaisePropertyChanged(() => CurrentAccount);
            SelectedAccountChanged?.Invoke(this, EventArgs.Empty);
        }

        //public async Task<bool> UpdateClient(ApplicationUser user, string imageUri = "")
        //{
        //    var userEx = new UserEx
        //    {
        //        FirstName = user?.FirstName,
        //        //Email = user?.Email,
        //        ImageUri = string.IsNullOrEmpty(imageUri) ? user?.ImageUri : imageUri,
        //        LastName = user?.LastName,
        //        Username = user?.UserName,
        //        Password = user?.CustomProperties.Password,
        //        Registration = user?.Registration,
        //    };

        //    CurrentAccount.User.ImageUri = userEx.ImageUri;

        //    var dic = new Dictionary<string, string>
        //        {
        //            { "id", user.Id }
        //        };

        //    var appUser = await ServiceClient.InvokeApiAsync<ApplicationUser>("ApplicationUser/GetById", System.Net.Http.HttpMethod.Get, dic);

        //    appUser.FirstName = userEx.FirstName;
        //    appUser.ImageUri = userEx.ImageUri;
        //    appUser.LastName = userEx.LastName;
        //    appUser.Registration = userEx.Registration;
        //    appUser.CustomProperties.Password = userEx.Password;
        //    appUser.Status = user.Status;
        //    appUser.DocumentIdentifier = user.DocumentIdentifier;

        //    var appUserResponse = await ServiceClient.InvokeApiAsync<UpdateApplicationUserCommand, ApplicationUser>("ApplicationUser/Update", cmd, HttpMethod.Patch, null);

        //    var service = new NaylahServiceClient(new Uri("https://sso.identity.naylah.co/"));

        //    return await service.InvokeApiAsync<UserEx, bool>("user/UpdateUser", userEx, HttpMethod.Patch, null);
        //}

        //public async Task<IList<UserEx>> GetSalesmanInfinitusUser(string dataStoreId)
        //{
        //    try
        //    {
        //        var dic = new Dictionary<string, string>();
        //        dic.Add("dataStoreId", dataStoreId);

        //        var u = await ServiceClient.InvokeApiAsync<IList<UserEx>>("Salesman/GetAllSalesmanByDataStoreId", HttpMethod.Get, dic);
        //        return u;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public void ResetAccount()
        {
            CurrentAccount = null;

            RaisePropertyChanged(() => CurrentAccount);
        }

        public async Task PrepareAccount()
        {
            var newAccount = new Account()
            {
                ServiceUser = (NaylahServiceUser)ServiceClient.CurrentUser
            };

            newAccount.User = await ServiceClient.InvokeApiAsync<ApplicationUser>("Account/Prepare", System.Net.Http.HttpMethod.Post, null);

            newAccount.User.ImageUri = newAccount.ServiceUser.ImageUri;

            if (newAccount.User != null)
            {
                CurrentAccount = newAccount;
                await SaveAccount();

                SignedIn?.Invoke(this, EventArgs.Empty);
            }
        }

        public async Task<bool> NaylahCallbackLogin(string uri)
        {
            var tokenResponse = await naylahIdentityService.ValidateAuthorizeResponse(uri);

            await naylahIdentityService.Login(tokenResponse);

            await PrepareAccount();

            return CurrentAccount != null;
        }

        public async Task RefreshSignIn(bool force = true)
        {
            ServiceClient.CurrentUser = CurrentAccount?.ServiceUser;

            await PrepareAccount();
        }

        public virtual async Task SaveAccount()
        {
            await Task.Delay(100);

            await CacheService?.Put(CurrentAccountCacheKey, CurrentAccount);
        }

        public virtual async Task LoadAccount()
        {
            CurrentAccount = await CacheService?.Get<Account>(CurrentAccountCacheKey);
        }

        public virtual async Task<bool> SignInBackground()
        {
            bool authenticated = false;

            try
            {
                await LoadAccount();

                if (CurrentAccount != null)
                {
                    if (AccessTokenIsNearToExpire(CurrentAccount?.ServiceUser))
                    {
                        await SignOut();
                        authenticated = false;
                    }

                    else
                    {
                        await RefreshSignIn();
                        authenticated = CurrentAccount != null;
                    }
                }

                if (!authenticated)
                {
                    ResetAccount();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return authenticated;
        }

        public async Task SignOut()
        {
            SignedOut?.Invoke(this, EventArgs.Empty);

            CurrentAccount = null;

            await naylahIdentityService.Logout();

            await SaveAccount();
        }

        public string GetNaylahIdentityAuthorizeUrl()
        {
            return ServiceClient.IdentityService.GetAuthorizeUrl();
        }

        public string GetNaylahClientIdCreateAccount()
        {
            return "https://sso.identity.naylah.co/core/register?clientId=" + ServiceClient.IdentityService.Settings.ClientId;
        }

        public string GetNaylahIdentityAuthorizeUrlDebug(string baseUrl = "https://192.168.18.111:3000/core/")
        {
            return baseUrl + "connect/authorize?client_id=" + ServiceClient.IdentityService.Settings.ClientId + "&response_type=code+id_token+token&scope=" + ServiceClient.IdentityService.Settings.Scope + "&redirect_uri=" + ServiceClient.IdentityService.Settings.RedirectUri + "&nonce=" + Guid.NewGuid().ToString();
        }

        public string GetNaylahIdentityRedirectUrl()
        {
            return ServiceClient.IdentityService.Settings.RedirectUri;
        }

        public bool AccessTokenIsNearToExpire(IServiceUser currentUser)
        {
            var diference = (currentUser.AccessTokenExpiresIn - DateTime.Now).TotalDays;

            return diference < 3;
        }

        public async Task<List<ApplicationUser>> GetAllAccountsAsync()
        {
            var list = new List<ApplicationUser>();

            var dic = new Dictionary<string, string>
            {
                { "applicationId", ApplicationService.CurrentApplication.Id }
            };

            list =
                await
                    ServiceClient.InvokeApiAsync<List<ApplicationUser>>(
                        "ApplicationUser/GetAllByApplicationId", HttpMethod.Get, dic);
            return list;
        }

        public async Task<ApplicationUserRelationship> GetRelationshipsByUserId(string userId)
        {
            var dic = new Dictionary<string, string>
            {
                { "userId", userId },
            };

            return await ServiceClient.InvokeApiAsync<ApplicationUserRelationship>("ApplicationUserRelationship/GetRelationshipsById", HttpMethod.Get, dic);
        }

        public async Task<ApplicationUserRelationshipStatus> CreateRelationship(string userId)
        {
            var dic = new Dictionary<string, string>
            {
                { "relationshipType", ApplicationUserRelationshipType.Friend.ToString() },
                { "appUserRelationToRequestId", userId }
            };

            var response = await ServiceClient.InvokeApiAsync<ApplicationUserRelationship>("ApplicationUserRelationship/RequestRelationship", HttpMethod.Post, dic);
            return response.RelationshipStatus;

        }

        public async Task PushMessage(SendAppUserMessageCommand message)
        {
            await ServiceClient.InvokeApiAsync<SendAppUserMessageCommand, SendAppUserMessageCommand>("ApplicationUserMessage/SendMessageTo", message);
        }

        public async Task<IList<ChatMessage>> GetMessagesForCurrentUser(int top, int skip, string relationUserId, string userId)
        {
            var dic = new Dictionary<string, string>
            {
                { "relationUserId", relationUserId },
                { "$top", top.ToString() },
                { "$skip", skip.ToString() },
                { "$orderby", "CreatedAt desc" }
            };

            var response = await ServiceClient.InvokeApiAsync<IList<ApplicationUserMessage>>("ApplicationUserMessage/GetAllMessagesWith", HttpMethod.Get, dic);

            var msgList = new List<ChatMessage>();

            foreach (var i in response)
            {
                msgList.Add(i.ToChatMessage(userId));
            }

            return msgList;

        }
    }



    public class UserEx
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUri { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Registration { get; set; }

        public string Password { get; set; }

        public string Unity { get; set; }
    }

    public class SendAppUserMessageCommand
    {
        public string ToId { get; set; }
        public string Content { get; set; }
    }

    public class ApplicationUserMessage : EntityBase
    {
        public string Content { get; set; }

        public string FromId { get; set; }

        public string ToId { get; set; }

        public ChatMessage ToChatMessage(string userId)
        {
            var msg = new ChatMessage()
            {
                Text = Content,
                Date = CreatedAt.Value.DateTime
            };

            if (ToId == userId)
                msg.SentBySelfUser = true;

            else
                msg.SentBySelfUser = false;

            return msg;
        }
    }

    public class ApplicationUserRelationship
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual string ApplicationUserId { get; set; }

        public virtual ApplicationUser Relation { get; set; }
        public virtual string RelationId { get; set; }

        public ApplicationUserRelationshipType RelationshipType { get; set; }

        public ApplicationUserRelationshipStatus RelationshipStatus { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
    }
}
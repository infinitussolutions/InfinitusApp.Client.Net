using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ApplicationUserService
{
    public class ApplicationUserService : ServiceBase
    {
        public ApplicationUserService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<ApplicationUser>> GetAllByApplicationId(string applicationId)
        {
            var dic = new Dictionary<string, string>
                {
                    { "applicationId", applicationId }
                };

            return await ServiceClient.InvokeApiAsync<List<ApplicationUser>>("ApplicationUser/GetAllByApplicationId", HttpMethod.Get, dic);
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

            return await ServiceClient.InvokeApiAsync<ApplicationUser>("ApplicationUser/GetById", HttpMethod.Get, dic);
        }

        public async Task<ApplicationUser> Update(UpdateApplicationUserCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateApplicationUserCommand, ApplicationUser>("ApplicationUser/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<bool> Delete()
        {
            return await ServiceClient.InvokeApiAsync<bool>("ApplicationUser/DeleteUser", HttpMethod.Post, null);
        }
    }
}

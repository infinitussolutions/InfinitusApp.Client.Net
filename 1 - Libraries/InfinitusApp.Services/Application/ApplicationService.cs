using InfinitusApp.Core.Extensions;
using InfinitusApp.Services.Infrastructure;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Application
{
    public class ApplicationService : ServiceBase
    {
        private const string ApplicationCacheKey = "ApplicationCacheKey";
        private InfinitusApp.Core.Data.DataModels.Application _currentApplication;
        private ICacheService cacheService;

        public ApplicationService(
           InfinitusAppServiceClient _serviceClient
           ) : base(_serviceClient)
        {
            ServiceClient = _serviceClient;
        }

        public ApplicationService(
            InfinitusAppServiceClient _serviceClient,
            ICacheService _cacheService
            ) : this(_serviceClient)
        {
            cacheService = _cacheService;
        }

        public event EventHandler SelectedApplicationChanged;

        public InfinitusApp.Core.Data.DataModels.Application CurrentApplication
        {
            get { return _currentApplication; }
            protected set
            {
                Set(ref _currentApplication, value);
                SelectedApplicationChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void RaiseCurrentApplicationChanged()
        {
            RaisePropertyChanged(nameof(CurrentApplication));
            SelectedApplicationChanged?.Invoke(this, EventArgs.Empty);
        }

        public async Task LoadFromCache()
        {
            var application = await cacheService?.Get<Core.Data.DataModels.Application>(ApplicationCacheKey);
            CurrentApplication = application ?? CurrentApplication;
        }

        public async Task SaveToCache()
        {
            await cacheService?.Put(ApplicationCacheKey, CurrentApplication);
        }

        public async Task<InfinitusApp.Core.Data.DataModels.Application> UpdateCurrentApplicationInfo()
        {
            CurrentApplication = await ServiceClient.MobileServiceClient.InvokeApiAsync<Core.Data.DataModels.Application>("Application/GetCurrent", HttpMethod.Get, null);

            await SaveToCache();

            return CurrentApplication;
        }

        public async Task ChangeCurrentApplicationInfo(string appId, string appSecret)
        {
            var dic = new Dictionary<string, string>
            {
                { "appId", appId }
            };

            ChangeServiceClient(appId, appSecret);

            CurrentApplication = await ServiceClient.MobileServiceClient.InvokeApiAsync<InfinitusApp.Core.Data.DataModels.Application>("Application/ChangeCurrent", HttpMethod.Get, dic);
        }

        public async Task<Core.Data.DataModels.Application> GetByAppId(string appId)
        {
            var dic = new Dictionary<string, string>
                {
                    { "appId", appId }
                };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Application>("Application/GetApplicationByAppId", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Application>> GetAllVisibleInFabricaApp()
        {
            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Application>>("Application/GetAllVisibleInFabricaApp", HttpMethod.Get, null);
        }


        //public async Task<List<InfinitusApp.Core.Data.DataModels.Application>> GetAllApplicationsInCompanyGroup()
        //{
        //    try
        //    {
        //        var dic = new Dictionary<string, string>();
        //        dic.Add("companyId", CurrentApplication.CompanyInformation.CompanyId);

        //        var app = await ServiceClient.MobileServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Application>>("Application/GetAllInCompanyGroup", HttpMethod.Get, dic);
        //        return app;
        //    }
        //    catch (MobileServiceInvalidOperationException ex)
        //    {
        //        var r = await ex.Response.Content.ReadAsStringAsync();
        //        return null;
        //    }

        //    catch (Exception e)
        //    {

        //        throw e;
        //    }

        //   // return CurrentApplication;
        //}

        public async Task LoadApplicationData()
        {
            await LoadFromCache();

            await UpdateCurrentApplicationInfo();
        }
    }
}
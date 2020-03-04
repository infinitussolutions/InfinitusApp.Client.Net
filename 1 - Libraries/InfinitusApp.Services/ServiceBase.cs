using GalaSoft.MvvmLight;
using System;

namespace InfinitusApp.Services
{
    public abstract class ServiceBase : ObservableObject
    {
        public ServiceBase(InfinitusAppServiceClient _serviceClient)
        {
            ServiceClient = _serviceClient;
            InstanceId = Guid.NewGuid().ToString();
            
        }

        public string InstanceId { get; set; }

        internal InfinitusAppServiceClient ServiceClient { get; set; }

        public void ChangeServiceClient(string appId, string appSecret)
        {
            ServiceClient.ServiceSettings.AppId = appId;
            ServiceClient.ServiceSettings.AppSecret = appSecret;
        }
    }
}
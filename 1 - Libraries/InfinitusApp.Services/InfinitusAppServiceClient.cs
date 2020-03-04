using Naylah.Identity.Client;
using Naylah.Service.Client.Services;
using Naylah.Services.Client;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitusApp.Services
{
    public partial class InfinitusAppServiceClient : NaylahServiceClient
    {
        protected InfinitusAppServiceClient(Uri serviceUri, InfinitusAppServiceSettings settings) : base(serviceUri, settings)
        {
            ServiceSettings = settings;
        }

        protected InfinitusAppServiceClient(Uri serviceUri) : base(serviceUri)
        {
        }

        public new InfinitusAppServiceSettings ServiceSettings { get; set; }
        public NaylahIdentityService IdentityService { get; set; }

        public static InfinitusAppServiceClient Create(
            InfinitusAppServiceAccess.EnvironmentsTypes environmentsType,
            string appId,
            string appSecret,
            string naylahIdentityClientId
            )
        {
            var settings = new InfinitusAppServiceSettings()
            {
                AppId = appId,
                AppSecret = appSecret
            };

            var serviceUri = InfinitusAppServiceAccess.GetServiceAccessUri(environmentsType);

            var nClient = new InfinitusAppServiceClient(serviceUri, settings);

            nClient.AddService(new InfinitusAppApplicationService());

            nClient.ConfigureNaylahIdentityService(naylahIdentityClientId); //default...

            return nClient;
        }

        public void ConfigureNaylahIdentityService(string naylahIdentityClientId = "infinitusapp.hybrid")
        {
            try
            {
                if (IdentityService?.Settings?.ClientId == naylahIdentityClientId)
                    return;

                if (this.Services.Contains(IdentityService))
                {
                    IdentityService.Dettach();

                    this.RemoveService(IdentityService);
                }

                IdentityService = new NaylahIdentityService(naylahIdentityClientId, "#infinitusapp@01", "openid email profile offline_access infinitusapp.service");

                this.AddService(IdentityService);
            }

            catch(Exception e)
            {
                
            }
        }

        public void ConfigureNaylahIdentityService(InfinitusApp.Core.Data.DataModels.Application currentApplication)
        {
            if (currentApplication == null)
                return;

            if (!string.IsNullOrEmpty(currentApplication.NaylahIdentityClient.ClientId))
                ConfigureNaylahIdentityService(currentApplication.NaylahIdentityClient.ClientId);
        }
    }

    public class InfinitusAppServiceSettings : NaylahServiceClientSettings
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }

    public class InfinitusAppApplicationService : INaylahServiceBase
    {
        public NaylahServiceClient ServiceClient { get; private set; }

        public void Attach(NaylahServiceClient serviceClient)
        {
            ServiceClient = serviceClient;

            ServiceClient.ServiceSettings.MessageHandlers.Add(new InfinitusAppServiceDefaultMessageHandler((InfinitusAppServiceClient)ServiceClient));
        }

        public void Dettach()
        {
        }
    }
}
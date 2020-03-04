using Naylah.Services.Client.MessageHandlers;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace InfinitusApp.Services
{
    public class InfinitusAppServiceDefaultMessageHandler : ServiceClientBaseDelegatingHandler
    {
        public InfinitusAppServiceDefaultMessageHandler(InfinitusAppServiceClient client)
        {
            InfinitusAppServiceClient = client;
        }

        private InfinitusAppServiceClient InfinitusAppServiceClient { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if ((InfinitusAppServiceClient.ServiceSettings != null) && !string.IsNullOrEmpty(InfinitusAppServiceClient.ServiceSettings.AppId) && (!string.IsNullOrEmpty(InfinitusAppServiceClient.ServiceSettings.AppSecret)))
            {
                request.Headers.TryAddWithoutValidation("infinitusappid", InfinitusAppServiceClient.ServiceSettings.AppId);
                request.Headers.TryAddWithoutValidation("infinitusappsecret", InfinitusAppServiceClient.ServiceSettings.AppSecret);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
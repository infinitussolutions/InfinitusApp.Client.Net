using Ebanx.net.Parameters.Responses.DirectOperation;
using Ebanx.net.Parameters.Responses.QueryOperation;
using InfinitusApp.Core.Data.Commands.ExternalDependence.Ebanx;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Ebanx
{
    public class EbanxService : ServiceBase
    {
        public EbanxService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<DirectResponse> DirectPayment(EbanxDirectPaymentCommand cmd)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<EbanxDirectPaymentCommand, DirectResponse>("Ebanx/DirectPayment", cmd);
        }

        public async Task<List<QueryResponse>> GetInvoice(string hash)
        {
            var dic = new Dictionary<string, string>
            {
                {"hash", hash }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<QueryResponse>>("Ebanx/GetInvoice", HttpMethod.Get, dic);
        }
    }
}

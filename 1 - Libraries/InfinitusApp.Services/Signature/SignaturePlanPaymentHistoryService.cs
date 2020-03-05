using InfinitusApp.Core.Data.DataModels.Signature;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Signature
{
    public class SignaturePlanPaymentHistoryService : ServiceBase
    {
        public SignaturePlanPaymentHistoryService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<SignaturePlanPaymentHistory>> GetAll()
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlanPaymentHistory>>("SignaturePlanPaymentHistory/GetAll", HttpMethod.Get, null);
        }
    }
}

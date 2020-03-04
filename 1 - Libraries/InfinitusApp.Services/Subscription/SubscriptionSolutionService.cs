using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Services._1___Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Subscription
{
    public class SubscriptionSolutionService : ServiceBase//, ISubscriptionSolutionService
    {
        public SubscriptionSolutionService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        //public async Task<SubscriptionSolutionApp> GetByIdWhitSolution(string subscriptionSolutionId)
        //{
        //    var dic = new Dictionary<string, string>();
        //    dic.Add("subscriptionSolutionId", subscriptionSolutionId);

        //    return await ServiceClient.InvokeApiAsync<SubscriptionSolutionApp>("SubscriptionSolution/GetByIdWithSolution", HttpMethod.Get, dic);
        //}

        public async Task<List<SubscriptionSolutionApp>> GetAllByCompanyId(string companyId, TimeSpan timeInCached, bool forceReflesh = false)
        {
            var dic = new Dictionary<string, string>
            {
                { "companyId", companyId }
            };

            return await ServiceClient.InvokeApiAsync<List<SubscriptionSolutionApp>>("SubscriptionSolution/GetAllByCompanyId", HttpMethod.Get, dic);
        }
    }
}

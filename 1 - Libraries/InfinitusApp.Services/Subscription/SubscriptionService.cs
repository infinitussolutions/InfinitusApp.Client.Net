using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Subscription
{
    public class SubscriptionService : ServiceBase
    {
        public SubscriptionService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<MarketplaceDataAccountEnvironment> GetActiveEvironmentBySubscriptionId(string subscriptionId)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("subscriptionId", subscriptionId);

            return await ServiceClient.InvokeApiAsync<MarketplaceDataAccountEnvironment>("Subscription/GetActiveEvironmentBySubscriptionId", HttpMethod.Get, dic);
        }
    }

    public enum MarketplaceDataAccountEnvironment
    {
        Test,
        Production
    }
}

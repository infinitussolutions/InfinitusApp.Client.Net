using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.FInancial
{
    public class MarketplaceService : ServiceBase
    {
        public MarketplaceService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<Marketplace> GetByDataStoreId(string dataStoreId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId }
            };

            return await ServiceClient.InvokeApiAsync<Marketplace>("Marketplace/GetByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

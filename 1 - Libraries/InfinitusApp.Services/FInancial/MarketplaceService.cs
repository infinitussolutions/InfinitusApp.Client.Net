using InfinitusApp.Core.Data.Commands;
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

        public async Task<Marketplace> Create(CreateMarketplaceCommand cmd)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<CreateMarketplaceCommand, Marketplace>("Marketplace/Create", cmd);
        }

        public async Task<Marketplace> Update(UpdateMarketplaceCommand cmd)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<UpdateMarketplaceCommand, Marketplace>("Marketplace/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<Marketplace> GetByDataStoreId(string dataStoreId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId }
            };

            return await ServiceClient.InvokeApiAsync<Marketplace>("Marketplace/GetByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<Marketplace> GetByDataItemId(string dataItemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId }
            };

            return await ServiceClient.InvokeApiAsync<Marketplace>("Marketplace/GetByDataItemId", HttpMethod.Get, dic);
        }
    }
}

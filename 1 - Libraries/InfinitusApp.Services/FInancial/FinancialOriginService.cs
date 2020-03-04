using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.FInancial
{
    public class FinancialOriginService : ServiceBase
    {
        public FinancialOriginService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<IList<FinancialOrigin>> GetAllByDataStoreId(string dataStoreId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId }
            };

            return await ServiceClient.InvokeApiAsync<IList<FinancialOrigin>>("FinancialOrigin/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<FinancialOrigin> GetById(string Id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", Id }
            };

            return await ServiceClient.InvokeApiAsync<FinancialOrigin>("FinancialOrigin/GetById", HttpMethod.Get, dic);
        }
    }
}

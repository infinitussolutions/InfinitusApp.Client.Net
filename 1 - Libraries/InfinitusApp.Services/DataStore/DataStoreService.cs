using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.DataStore
{
    public class DataStoreService : ServiceBase
    {
        public DataStoreService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<Core.Data.DataModels.FinancialParameters> GetFinancialParametersByDataStoreId(string dataStoreId)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", dataStoreId }
                };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.FinancialParameters>("DataStore/GetFinancialParametersByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

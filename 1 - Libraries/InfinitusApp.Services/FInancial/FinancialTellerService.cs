using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.FInancial
{
    public class FinancialTellerService : ServiceBase
    {
        public FinancialTellerService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<IList<FinancialTeller>> GetAllByDataStoreId(string dataStoreId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId }
            };

            return await ServiceClient.InvokeApiAsync<IList<FinancialTeller>>("FinancialTeller/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

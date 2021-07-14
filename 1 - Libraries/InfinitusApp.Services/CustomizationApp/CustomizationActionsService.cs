using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.CustomizationApp
{
    public class CustomizationActionsService : ServiceBase
    {
        public CustomizationActionsService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<CustomizationActions>> GetAllByDataStoreId(string dataStoreId)
        {
            try
            {
                var dic = new Dictionary<string, string>()
                {
                    { "dataStoreId", dataStoreId }

                };

                return await ServiceClient.InvokeApiAsync<List<CustomizationActions>>("CustomizationApp/CustomizationActions/GetAllByDataStoreId", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CustomizationActions>> GetAllByDataStoreIdAndReferency(string dataStoreId, string referencyId)
        {
            try
            {
                var dic = new Dictionary<string, string>()
                {
                    { "dataStoreId", dataStoreId },
                    { "referencyId", referencyId }
                };

                return await ServiceClient.InvokeApiAsync<List<CustomizationActions>>("CustomizationApp/CustomizationActions/GetAllByDataStoreIdAndReferency", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

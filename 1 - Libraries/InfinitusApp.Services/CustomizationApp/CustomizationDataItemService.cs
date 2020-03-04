using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.CustomizationApp
{
    public class CustomizationDataItemService : ServiceBase
    {
        public CustomizationDataItemService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<CustomizationDataItem>> GetAllByDataStoreId(string dataStoreId)
        {
            try
            {
                var dic = new Dictionary<string, string>()
                {
                    { "dataStoreId", dataStoreId }
                    
                };

                return await ServiceClient.InvokeApiAsync<List<CustomizationDataItem>>("CustomizationApp/CustomizationDataItem/GetAllByDataStoreId", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CustomizationDataItem>> GetAllByDataStoreIdAndReferency(string dataStoreId, string referencyId)
        {
            try
            {
                var dic = new Dictionary<string, string>()
                {
                    { "dataStoreId", dataStoreId },
                    { "referencyId", referencyId }
                };

                return await ServiceClient.InvokeApiAsync<List<CustomizationDataItem>>("CustomizationApp/CustomizationDataItem/GetAllByDataStoreIdAndReferency", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

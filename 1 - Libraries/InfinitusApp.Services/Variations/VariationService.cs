using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Variations
{
    public class VariationService : ServiceBase
    {
        public VariationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<Core.Data.DataModels.Variation>> GetAllByDataItemId(string dataitemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataitemId", dataitemId }
            };

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Variation>>("Variations/Variation/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task<Core.Data.DataModels.Variation> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Variation>("Variations/Variation/GetById", HttpMethod.Get, dic);
        }
    }
}

using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Customization
{
    public class CustomizationVisibleService : ServiceBase
    {
        private const string UrlBase = "Customization/CustomizationVisible/";

        public CustomizationVisibleService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<CustomizationVisible>> GetAllByReferency(string referencyId)
        {
            var dic = new Dictionary<string, string>
                {
                    { "ReferencyId", referencyId }
                };

            return await ServiceClient.InvokeApiAsync<List<CustomizationVisible>>(UrlBase + "GetAllByReferency", HttpMethod.Get, dic);
        }
    }
}

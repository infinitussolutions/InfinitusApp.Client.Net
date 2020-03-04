using InfinitusApp.Core.Data.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Group
{
    public class SubGroupRecommendationService : ServiceBase
    {
        public SubGroupRecommendationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<SubGroupRecommendation>> GetAllBySubGroupId(string subGroupId)
        {
            var dic = new Dictionary<string, string>
            {
                { "subGroupId", subGroupId },
            };

            return await ServiceClient.InvokeApiAsync<List<SubGroupRecommendation>>("Group/SubGroupRecommendation/GetAllBySubGroupId", HttpMethod.Get, dic);
        }
    }
}

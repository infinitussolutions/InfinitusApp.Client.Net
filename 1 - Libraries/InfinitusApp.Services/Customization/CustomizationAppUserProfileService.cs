using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Customization
{
    public class CustomizationAppUserProfileService : ServiceBase
    {
        public CustomizationAppUserProfileService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<CustomizationAppUserProfile>> GetAllByApplicationId()
        {
            return await ServiceClient.InvokeApiAsync<List<CustomizationAppUserProfile>>("Customization/CustomizationAppUserProfile/GetAllByApplicationId", HttpMethod.Get, null);
        }
    }
}

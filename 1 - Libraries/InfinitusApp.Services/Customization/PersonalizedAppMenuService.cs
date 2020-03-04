using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Customization
{
    public class PersonalizedAppMenuService : ServiceBase
    {
        public PersonalizedAppMenuService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<PersonalizedAppMenu>> GetAllByApplicationId(CustomizationReferencyDescription referencyDescription, string appId)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("applicationId", appId);
            dic.Add("personalizedAppMenuReferencyDescription", referencyDescription.ToString());

            return await ServiceClient.InvokeApiAsync<List<PersonalizedAppMenu>>("Customization/PersonalizedAppMenu/GetAllByApplicationIdWithRelations", HttpMethod.Get, dic);
        }
    }
}

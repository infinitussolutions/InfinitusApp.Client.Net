using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Customization
{
    public class PersonalizedDataItemService : ServiceBase
    {
        public PersonalizedDataItemService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<PersonalizedDataItem> GetByReferency(CustomizationReferencyDescription personalizedDataItemDescription, string referencyId, string appId)
        {
            try
            {
                var dic = new Dictionary<string, string>
                {
                    { "appId", appId },
                    { "personalizedDataItemDescription", personalizedDataItemDescription.ToString()},
                    {"referencyId", referencyId }
                };

                return await ServiceClient.InvokeApiAsync<PersonalizedDataItem>("Customization/PersonalizedDataItem/GetByReferency", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

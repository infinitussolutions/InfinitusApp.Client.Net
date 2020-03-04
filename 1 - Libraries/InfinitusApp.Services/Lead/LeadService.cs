using InfinitusApp.Core.Data.DataModels;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Lead
{
    public class LeadService : ServiceBase
    {
        public LeadService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Core.Data.DataModels.Lead> Register(CreateLeadCommand createLeadCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateLeadCommand, Core.Data.DataModels.Lead>("Lead/Register", createLeadCommand);
        }
    }
}
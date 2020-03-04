using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Indication
{
    public class IndicationService : ServiceBase
    {
        public IndicationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Core.Data.DataModels.Indication> Create(CreateIndicationCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateIndicationCommand, Core.Data.DataModels.Indication>("Indication/Create", cmd);
        }

        public async Task<Core.Data.DataModels.Indication> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Indication>("Indication/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Indication>> GetAllByApplicationId(string applicationId)
        {
            var dic = new Dictionary<string, string>
            {
                { "applicationId", applicationId }
            };

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Indication>>("Indication/GetAllByApplicationId", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Indication>> GetAllByApplicationIdAndUserId(string applicationId, string applicationUserId)
        {
            var dic = new Dictionary<string, string>
            {
                { "applicationId", applicationId },
                { "applicationUserId", applicationUserId }
            };

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Indication>>("Indication/GetAllByApplicationIdAndUserId", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Indication>> GetAllByDataItemId(string dataItemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId }
            };

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Indication>>("Indication/GetAllByDataItemId", HttpMethod.Get, dic);
        }
    }
}

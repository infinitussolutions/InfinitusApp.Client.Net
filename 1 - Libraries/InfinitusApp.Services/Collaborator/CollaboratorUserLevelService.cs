using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Collaborator
{
    public class CollaboratorUserLevelService : ServiceBase
    {
        public CollaboratorUserLevelService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<CollaboratorUserLevel> Create(CollaboratorUserLevelCreateCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CollaboratorUserLevelCreateCommand, CollaboratorUserLevel>("CollaboratorUserLevel/Create", cmd);
        }

        public async Task<CollaboratorUserLevel> Update(CollaboratorUserLevelUpdateCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CollaboratorUserLevelUpdateCommand, CollaboratorUserLevel>("CollaboratorUserLevel/Update", cmd);
        }

        public async Task<CollaboratorUserLevel> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<CollaboratorUserLevel>("CollaboratorUserLevel/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<CollaboratorUserLevel>> GetAllByDataItemId(string dataItemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId }
            };

            return await ServiceClient.InvokeApiAsync<List<CollaboratorUserLevel>>("CollaboratorUserLevel/GetAllByDataItemId", HttpMethod.Get, dic);
        }
    }
}

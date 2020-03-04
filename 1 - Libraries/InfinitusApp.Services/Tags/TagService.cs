using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Tags
{
    public class TagService : ServiceBase
    {
        public TagService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<Core.Data.DataModels.Tag> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Tag>("Tag/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Tag>> GetAllByDataStoreId(string dataStoreId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId }
            };

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Tag>>("Tag/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<Core.Data.DataModels.Tag> Update(TagUpdateCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<TagUpdateCommand, Core.Data.DataModels.Tag>("Tag/Update", cmd, HttpMethod.Patch, null);
        }
    }
}

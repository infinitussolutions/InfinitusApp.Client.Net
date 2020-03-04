using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Phone
{
    public class PhoneService : ServiceBase
    {
        public PhoneService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Core.Data.DataModels.Phone> Create(CreatePhoneCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreatePhoneCommand, Core.Data.DataModels.Phone>("Phone/Create", cmd);
        }

        public async Task<Core.Data.DataModels.Phone> Update(UpdatePhoneCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdatePhoneCommand, Core.Data.DataModels.Phone>("Phone/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<Core.Data.DataModels.Phone> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Phone>("Phone/GetById", HttpMethod.Get, dic);
        }

        public async Task<IList<Core.Data.DataModels.Phone>> GetAllByApplicationUserId(string applicationUserId)
        {
            var dic = new Dictionary<string, string>
            {
                { "applicationUserId", applicationUserId }
            };

            return await ServiceClient.InvokeApiAsync<IList<Core.Data.DataModels.Phone>>("Phone/GetAllByApplicationUserId", HttpMethod.Get, dic);
        }

        public async Task<IList<Core.Data.DataModels.Phone>> GetAllByDataItemId(string dataItemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId }
            };

            return await ServiceClient.InvokeApiAsync<IList<Core.Data.DataModels.Phone>>("Phone/GetAllByDataItemId", HttpMethod.Get, dic);
        }
    }
}

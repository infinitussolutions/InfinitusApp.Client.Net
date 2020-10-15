using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.ComboModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ComboServices
{
    public class ComboItemService : ServiceBase
    {
        public ComboItemService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<ComboItem> Create(CreateComboItemCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateComboItemCommand, ComboItem>(nameof(ComboItem) + "/Create", cmd);
        }

        public async Task<ComboItem> Update(UpdateComboItemCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateComboItemCommand, ComboItem>(nameof(ComboItem) + "/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<ComboItem> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id",id }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<ComboItem>(nameof(ComboItem) + "/GetById", HttpMethod.Get, dic);
        }
    }
}

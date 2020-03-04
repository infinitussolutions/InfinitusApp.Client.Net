using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.Commands.DataItem;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitusApp.Services.DataItem
{
    public class DataItemMediaService : ServiceBase
    {
        public DataItemMediaService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<DataItemMedia>> GetDataItemMedia(string dataItemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId }
            };

            return await ServiceClient.InvokeApiAsync<List<DataItemMedia>>("DataItemMedia/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task Delete(string dataItemMediaId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemMediaId", dataItemMediaId }
            };

            await ServiceClient.InvokeApiAsync<List<DataItemMedia>>("DataItemMedia/Delete", HttpMethod.Delete, dic);
        }

        public async Task<DataItemMedia> Create(CreateDataItemMediaCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateDataItemMediaCommand, DataItemMedia>("DataItemMedia/Create", command);
        }
    }
}
using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.DataStore
{
    public class DataItemInteractionsService : ServiceBase
    {
        public DataItemInteractionsService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<DataItemInteractions> RegisterInteraction(DataItemInteractions interaction)
        {
            return await ServiceClient.InvokeApiAsync<DataItemInteractions, DataItemInteractions>("Interactions/Register", interaction);
        }

        public async Task<DataItemInteractions> UpdateInteraction(DataItemInteractions interaction)
        {
            return await ServiceClient.InvokeApiAsync<DataItemInteractions, DataItemInteractions>("Interactions/Update", interaction, HttpMethod.Post, null);
        }

        public async Task<List<DataItemInteractions>> GetAllByDataItemId(string id)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("id", id);

            return await ServiceClient.InvokeApiAsync<List<DataItemInteractions>>("Interactions/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task<List<DataItemInteractions>> GetAllByPublicationId(string id)
        {
            try
            {
                var dic = new Dictionary<string, string>();
                dic.Add("id", id);

                return await ServiceClient.InvokeApiAsync<List<DataItemInteractions>>("Interactions/GetAllByPublicationId", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}

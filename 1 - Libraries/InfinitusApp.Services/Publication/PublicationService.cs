using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Publication
{
    public class PublicationService : ServiceBase
    {
        public PublicationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<Core.Data.DataModels.Publication>> GetAllByDataStoreId(string dataStoreId, TimeSpan timeInCached, bool onlyPaid = false, int skip = 0, int top = 10, string filter = "")
        {
            var query = new ODataQueryBuilder<Core.Data.DataModels.Publication>(string.Empty)
                    .For<Core.Data.DataModels.Publication>(x => x)
                    .ByList()
                    .Top(top)
                    .Skip(skip)
                    .OrderByDescending(x => x.CreatedAt)
                    ;

            if (string.IsNullOrEmpty(filter))
                query.Filter(x => x.ShowOnFeed == true);

            var dic = query.ToDictionary();

            if (!string.IsNullOrEmpty(filter))
                dic.Add("$filter", filter);

            dic.Add("dataStoreId", dataStoreId.ToString());
            dic.Add("onlyPaid", onlyPaid.ToString());
            

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Publication>>("Publication/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Publication>> GetPublicationsForAppAndUser()
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Publication>>("Publication/GetPublicationsForAppAndUser", HttpMethod.Get, null);
        }

        public async Task<Core.Data.DataModels.Publication> GetById(string publicationId)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", publicationId }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<Core.Data.DataModels.Publication>("Publication/GetById", HttpMethod.Get, dic);
        }

        public async Task<Core.Data.DataModels.Publication> Register(Core.Data.DataModels.Publication publication)
        {
            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Publication, Core.Data.DataModels.Publication>("Publication/Register", publication);
        }

        public async Task<Core.Data.DataModels.Publication> Delete(Core.Data.DataModels.Publication publication)
        {
            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Publication, Core.Data.DataModels.Publication>("Publication/Delete", publication, HttpMethod.Delete, null);
        }
    }
}
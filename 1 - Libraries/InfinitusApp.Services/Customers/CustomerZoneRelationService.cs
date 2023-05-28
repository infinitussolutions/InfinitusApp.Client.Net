using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Customers
{
    public class CustomerZoneRelationService : ServiceBase
    {
        public CustomerZoneRelationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<CustomerZoneRelation> Create(CustomerZoneRelationCreateCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CustomerZoneRelationCreateCommand, CustomerZoneRelation>("CustomerZoneRelation/Create", command, HttpMethod.Post, null);
        }

        public async Task<CustomerZoneRelation> Update(CustomerZoneRelationUpdateCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CustomerZoneRelationUpdateCommand, CustomerZoneRelation>("CustomerZoneRelation/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("CustomerZoneRelation/Delete", HttpMethod.Delete, dic);
        }

        public async Task<CustomerZoneRelation> GetById(string id)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

            return await ServiceClient.InvokeApiAsync<CustomerZoneRelation>("CustomerZoneRelation/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<CustomerZoneRelation>> GetAllByDataStoreId(string dataStoreId, Expression<Func<CustomerZoneRelation, bool>> entityFilter = null, Expression<Func<CustomerZoneRelation, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<CustomerZoneRelation>("")
                    .For<CustomerZoneRelation>(x => x)
                    .ByList();

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
            {
                if (desc)
                    odataBuilder.OrderByDescending(entityOrderBy);

                else
                    odataBuilder.OrderBy(entityOrderBy);
            }

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<CustomerZoneRelation>>("CustomerZoneRelation/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<List<CustomerZoneRelation>> GetAllByUser(string appUserId)
        {
            var dic = new Dictionary<string, string>
                {
                    { "appUserId", appUserId }
                };

            return await ServiceClient.InvokeApiAsync<List<CustomerZoneRelation>>("CustomerZoneRelation/GetAllByUser", HttpMethod.Get, dic);
        }
    }
}

using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Customers
{
    public class CustomerZoneService : ServiceBase
    {
        public CustomerZoneService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<CustomerZone> Create(CreateCustomerZoneCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateCustomerZoneCommand, CustomerZone>("CustomerZone/Create", command, HttpMethod.Post, null);
        }

        public async Task<CustomerZone> Update(UpdateCustomerZoneCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateCustomerZoneCommand, CustomerZone>("CustomerZone/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("CustomerZone/Delete", HttpMethod.Delete, dic);
        }

        public async Task<CustomerZone> GetById(string id)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

            return await ServiceClient.InvokeApiAsync<CustomerZone>("CustomerZone/GetById", HttpMethod.Get, dic);
        }

        public async Task<CustomerZone> GetByIdWithRelations(string id)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

            return await ServiceClient.InvokeApiAsync<CustomerZone>("CustomerZone/GetByIdWithRelations", HttpMethod.Get, dic);
        }

        public async Task<List<CustomerZone>> GetAllByDataStoreId(string dataStoreId, Expression<Func<CustomerZone, bool>> entityFilter = null, Expression<Func<CustomerZone, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<CustomerZone>("")
                    .For<CustomerZone>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<CustomerZone>>("CustomerZone/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

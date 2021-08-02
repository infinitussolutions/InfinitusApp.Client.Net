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
    public class CustomerTypeService : ServiceBase
    {
        public CustomerTypeService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<CustomerType> Create(CreateCustomerTypeCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateCustomerTypeCommand, CustomerType>("CustomerType/Create", command, HttpMethod.Post, null);
        }

        public async Task<CustomerType> Update(UpdateCustomerTypeCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateCustomerTypeCommand, CustomerType>("CustomerType/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("CustomerType/Delete", HttpMethod.Delete, dic);
        }

        public async Task<CustomerType> GetById(string id)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

            return await ServiceClient.InvokeApiAsync<CustomerType>("CustomerType/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<CustomerType>> GetAllByDataStoreId(string dataStoreId, Expression<Func<CustomerType, bool>> entityFilter = null, Expression<Func<CustomerType, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<CustomerType>("")
                    .For<CustomerType>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<CustomerType>>("CustomerType/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

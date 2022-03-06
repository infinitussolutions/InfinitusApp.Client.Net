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
    public class CustomerClassService : ServiceBase
    {
        public CustomerClassService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<CustomerClass> Create(CreateCustomerClassCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateCustomerClassCommand, CustomerClass>("CustomerClass/Create", command, HttpMethod.Post, null);
        }

        public async Task<CustomerClass> Update(UpdateCustomerClassCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateCustomerClassCommand, CustomerClass>("CustomerClass/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("CustomerClass/Delete", HttpMethod.Delete, dic);
        }

        public async Task<CustomerClass> GetById(string id)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

            return await ServiceClient.InvokeApiAsync<CustomerClass>("CustomerClass/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<CustomerClass>> GetAllByDataStoreId(string dataStoreId, Expression<Func<CustomerClass, bool>> entityFilter = null, Expression<Func<CustomerClass, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<CustomerClass>("")
                    .For<CustomerClass>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<CustomerClass>>("CustomerClass/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

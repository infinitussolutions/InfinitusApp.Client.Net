using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfinitusApp.Services.SalesOrder
{
    public class CustomerService : ServiceBase
    {
        public CustomerService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<IList<Customer>> GetAllByDataStoreId(string entityFilter = null, Expression<Func<Customer, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false, string orderBy = null)
        {
            var odataBuilder = new ODataQueryBuilder<Customer>("")
                    .For<Customer>(x => x)
                    .ByList()
                    ;

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            //if (entityFilter != null)
            //    odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
            {
                if (desc)
                    odataBuilder.OrderByDescending(entityOrderBy);

                else
                    odataBuilder.OrderBy(entityOrderBy);
            }


            var dic = odataBuilder.ToDictionary();

            if (!string.IsNullOrEmpty(entityFilter))
                dic.Add("$filter", entityFilter);

            if(!string.IsNullOrEmpty(orderBy) && entityOrderBy == null)
                dic.Add("$orderby", entityFilter);

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<Customer>>("Customer/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<Customer> GetByEmail(string email)
        {
            var dic = new Dictionary<string, string>
            {
                { "email", email }
            };

            return await ServiceClient.InvokeApiAsync<Customer>("Customer/GetByEmail", HttpMethod.Get, dic);
        }

        public async Task<Customer> Update(UpdateCustomerCommand updateCommand)
        {
            return await ServiceClient.InvokeApiAsync<UpdateCustomerCommand, Customer>("Customer/Update", updateCommand, HttpMethod.Patch, null);
        }


        public async Task<Customer> Create(CreateCustomerCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateCustomerCommand, Customer>("Customer/Create", createCommand);
        }
    }
}
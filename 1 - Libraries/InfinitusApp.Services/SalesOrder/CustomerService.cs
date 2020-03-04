using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitusApp.Services.SalesOrder
{
    public class CustomerService : ServiceBase
    {
        public CustomerService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<IList<Customer>> GetAllCustomerByDadaStoreId(string datastoreId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", datastoreId }
            };

            return await ServiceClient.InvokeApiAsync<IList<Customer>>("Customer/GetAllByDataStoreId", HttpMethod.Get, dic);
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
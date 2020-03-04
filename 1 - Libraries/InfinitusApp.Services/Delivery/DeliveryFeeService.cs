using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Delivery
{
    public class DeliveryFeeService : ServiceBase
    {
        public DeliveryFeeService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<DeliveryFee> Create(CreateDeliveryFeeCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateDeliveryFeeCommand, DeliveryFee>("DeliveryFee/Create", cmd);
        }

        public async Task<DeliveryFee> Update(UpdateDeliveryFeeCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateDeliveryFeeCommand, DeliveryFee>("DeliveryFee/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<DeliveryFee> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<DeliveryFee>("DeliveryFee/GetById", HttpMethod.Get, dic);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("DeliveryFee/Delete", HttpMethod.Delete, dic);
        }

        public async Task<IList<DeliveryFee>> GetAllByDataItemId(string dataItemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId }
            };

            return await ServiceClient.InvokeApiAsync<IList<DeliveryFee>>("DeliveryFee/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task<List<DeliveryFee>> GetAllByDataStoreId(string dataStoreId, Expression<Func<DeliveryFee, bool>> entityFilter = null, Expression<Func<DeliveryFee, object>> OrderByPropertyName = null, int skip = 0, int top = 10)
        {
            var odataBuilder = new ODataQueryBuilder<DeliveryFee>("")
                  .For<DeliveryFee>(x => x)
                  .ByList()
                  .Top(top)
                  .Skip(skip)
                  ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (OrderByPropertyName != null)
            {
                odataBuilder.OrderByDescending(OrderByPropertyName);
            }

            else
                odataBuilder.OrderBy(x => x.CreatedAt);

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);

            return await ServiceClient.InvokeApiAsync<List<DeliveryFee>>("DeliveryFee/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

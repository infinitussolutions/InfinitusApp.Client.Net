using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.PaymentCondition
{
    public class PaymentConditionRelationService : ServiceBase
    {
        public PaymentConditionRelationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<PaymentConditionRelation> Create(CreatePaymentConditionRelationCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreatePaymentConditionRelationCommand, PaymentConditionRelation>("PaymentConditionRelation/Create", command, HttpMethod.Post, null);
        }

        public async Task<bool> Deleted(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("PaymentConditionRelation/Delete", HttpMethod.Delete, dic);
        }

        public async Task<List<PaymentConditionRelation>> GetAll(Expression<Func<PaymentConditionRelation, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.PaymentConditionRelation, object>> entityOrderBy = null, int skip = 0, int top = 10, bool desc = false, string filterString = null)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.PaymentConditionRelation>("")
                    .For<Core.Data.DataModels.PaymentConditionRelation>(x => x)
                    .ByList()
                    .Top(top)
                    .Skip(skip)
                    ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
            {
                if (desc)
                    odataBuilder.OrderByDescending(entityOrderBy);

                else
                    odataBuilder.OrderBy(entityOrderBy);
            }

            else
                odataBuilder.OrderByDescending(x => x.CreatedAt);

            var dic = odataBuilder.ToDictionary();

            if (entityFilter == null && !string.IsNullOrEmpty(filterString))
                dic.Add("$filter", filterString);

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.PaymentConditionRelation>>("PaymentConditionRelation/GetAll", HttpMethod.Get, dic);
        }



    }
}

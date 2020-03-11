using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.FInancial
{
    public class PaymentConditionService : ServiceBase
    {
        public PaymentConditionService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<PaymentCondition>> GetAll(Expression<Func<PaymentCondition, bool>> entityFilter = null, Expression<Func<PaymentCondition, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<PaymentCondition>("")
                    .For<PaymentCondition>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<PaymentCondition>>("PaymentCondition/GetAll", HttpMethod.Get, dic);
        }
    }
}

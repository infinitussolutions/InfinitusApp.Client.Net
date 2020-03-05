using InfinitusApp.Core.Data.DataModels.Signature;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Signature
{
    public class SignaturePlanPaymentHistoryService : ServiceBase
    {
        public SignaturePlanPaymentHistoryService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<SignaturePlanPaymentHistory>> GetAll(Expression<Func<SignaturePlanPaymentHistory, bool>> entityFilter = null, Expression<Func<SignaturePlanPaymentHistory, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<SignaturePlanPaymentHistory>("")
                    .For<SignaturePlanPaymentHistory>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlanPaymentHistory>>("SignaturePlanPaymentHistory/GetAll", HttpMethod.Get, dic);
        }
    }
}

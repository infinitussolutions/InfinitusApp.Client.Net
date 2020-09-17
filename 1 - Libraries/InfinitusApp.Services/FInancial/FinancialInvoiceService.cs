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
    public class FinancialInvoiceService : ServiceBase
    {
        public FinancialInvoiceService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<FinancialInvoice>> GetAllByDataStoreId(string dataStoreId, Expression<Func<FinancialInvoice, bool>> entityFilter = null, int skip = 0, int top = 10)
        {
            var odataBuilder = new ODataQueryBuilder<FinancialInvoice>("")
                 .For<FinancialInvoice>(x => x)
                 .ByList()
                 .Top(top)
                 .Skip(skip)
                 .OrderByDescending(x => x.CreatedAt)
                 ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);

            return await ServiceClient.InvokeApiAsync<List<FinancialInvoice>>("FinancialInvoice/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

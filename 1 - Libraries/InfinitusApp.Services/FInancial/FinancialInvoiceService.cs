using InfinitusApp.Core.Data.Commands.OData;
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

        public async Task<List<FinancialInvoice>> GetAllByDataStoreId(string dataStoreId, ODataFilter filter = null, Expression<Func<FinancialInvoice, bool>> entityFilter = null, int month = 0, int year = 0 )
        {
            if (filter == null)
                filter = new ODataFilter();

            var odataBuilder = new ODataQueryBuilder<FinancialInvoice>("")
                 .For<FinancialInvoice>(x => x)
                 .ByList()
                 .Top(filter.Top)
                 .Skip(filter.Skip)
                 .OrderByDescending(x => x.CreatedAt)
                 ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);
            dic.Add("month", month.ToString());
            dic.Add("year", year.ToString());

            return await ServiceClient.InvokeApiAsync<List<FinancialInvoice>>("FinancialInvoice/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<List<FinancialInvoice>> GetMonthTotal(string dataStoreId, int month = 0, int year = 0)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId },
                { "month", month.ToString() },
                { "year", year.ToString() }
            };

            return await ServiceClient.InvokeApiAsync<List<FinancialInvoice>>("FinancialInvoice/GetMonthTotal", HttpMethod.Get, dic);
        }
    }
}

using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.Fidelity;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Fidelity
{
    public class FidelityExpenseService : ServiceBase
    {
        public FidelityExpenseService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<FidelityExpense> Create(CreateFidelityExpenseCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateFidelityExpenseCommand, FidelityExpense>("Fidelity/Expense/Create", command, HttpMethod.Post, null);
        }

        public async Task<List<FidelityExpense>> GetAllByDataStoreId(string dataStoreId, Expression<Func<FidelityExpense, bool>> entityFilter = null, Expression<Func<FidelityExpense, object>> entityOrderBy = null, int? skip = null, int? top = null)
        {
            var odataBuilder = new ODataQueryBuilder<FidelityExpense>("")
                    .For<FidelityExpense>(x => x)
                    .ByList()
                    .OrderByDescending(x => x.CreatedAt)
                    ;

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
                odataBuilder.OrderBy(entityOrderBy);

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);

            return await ServiceClient.InvokeApiAsync<List<FidelityExpense>>("Fidelity/Expense/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

using InfinitusApp.Core.Data.Commands;
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
    public class FinancialRequestStatusRelationService : ServiceBase
    {
        public FinancialRequestStatusRelationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<FinancialRequestStatusRelation> Create(CreateFinancialRequestStatusRelationCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateFinancialRequestStatusRelationCommand, FinancialRequestStatusRelation>("FinancialRequestStatusRelation/Create", createCommand);
        }

        public async Task<List<FinancialRequestStatusRelation>> GetAllWithoutStatusClosed(Expression<Func<FinancialRequestStatusRelation, bool>> entityFilter = null, Expression<Func<FinancialRequestStatusRelation, object>> entityOrderBy = null, int? skip = null, int? top = null)
        {
            var odataBuilder = new ODataQueryBuilder<FinancialRequestStatusRelation>("")
               .For<FinancialRequestStatusRelation>(x => x)
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

            return await ServiceClient.InvokeApiAsync<List<FinancialRequestStatusRelation>>(nameof(FinancialRequestStatusRelation) + "/GetAllWithoutStatusClosed", HttpMethod.Get, dic);
        }
    }
}

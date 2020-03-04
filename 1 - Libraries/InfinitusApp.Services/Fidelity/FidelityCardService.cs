using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.Fidelity;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Fidelity
{
    public class FidelityCardService : ServiceBase
    {
        public FidelityCardService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<FidelityCard> Create(CreateFidelityCardCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateFidelityCardCommand, FidelityCard>("Fidelity/Card/Create", command, HttpMethod.Post, null);
        }

        public async Task<List<FidelityCard>> GetAllByDataStoreId(string dataStoreId, Expression<Func<FidelityCard, bool>> entityFilter = null, Expression<Func<FidelityCard, object>> entityOrderBy = null, int? skip = null, int? top = null)
        {
            var odataBuilder = new ODataQueryBuilder<FidelityCard>("")
                    .For<FidelityCard>(x => x)
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

            return await ServiceClient.InvokeApiAsync<List<FidelityCard>>("Fidelity/Card/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

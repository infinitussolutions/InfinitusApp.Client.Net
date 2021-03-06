﻿using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.Fidelity;
using InfinitusApp.Core.Extensions;
using Newtonsoft.Json;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Fidelity
{
    public class FidelityPlanService : ServiceBase
    {
        public FidelityPlanService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<FidelityPlan> Create(CreateFidelityPlanCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateFidelityPlanCommand, FidelityPlan>("Fidelity/Plan/Create", command, HttpMethod.Post, null);
        }

        public async Task<FidelityPlan> Update(UpdateFidelityPlanCommand command)
        {
            return await ServiceClient.InvokeApiAsync<UpdateFidelityPlanCommand, FidelityPlan>("Fidelity/Plan/Update", command, HttpMethod.Patch, null);
        }

        public async Task<List<FidelityPlan>> GetAllByDataStoreId(string dataStoreId, Expression<Func<FidelityPlan, bool>> entityFilter = null, Expression<Func<FidelityPlan, object>> entityOrderBy = null, int? skip = null, int? top = null)
        {
            var odataBuilder = new ODataQueryBuilder<FidelityPlan>("")
               .For<FidelityPlan>(x => x)
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

            return await ServiceClient.InvokeApiAsync<List<FidelityPlan>>("Fidelity/Plan/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.Signature;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Signature
{
    public class SignaturePlanConsumptionService : ServiceBase
    {
        public SignaturePlanConsumptionService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<SignaturePlanConsumption> Create(CreateSignaturePlanConsumptionCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateSignaturePlanConsumptionCommand, SignaturePlanConsumption>("SignaturePlanConsumption/Create", createCommand);
        }

        public async Task<SignaturePlanConsumption> Update(UpdateSignaturePlanConsumptionCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateSignaturePlanConsumptionCommand, SignaturePlanConsumption>("SignaturePlanConsumption/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<List<SignaturePlanConsumption>> GetAll(string signaturePlanId, Expression<Func<SignaturePlanConsumption, bool>> entityFilter = null, Expression<Func<SignaturePlanConsumption, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<SignaturePlanConsumption>("")
                    .For<SignaturePlanConsumption>(x => x)
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

            dic.Add("signaturePlanId", signaturePlanId);

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlanConsumption>>("SignaturePlanConsumption/GetAll", HttpMethod.Get, dic);
        }
    }
}

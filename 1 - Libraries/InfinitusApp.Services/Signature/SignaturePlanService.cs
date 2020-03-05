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
    public class SignaturePlanService : ServiceBase
    {
        public SignaturePlanService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<SignaturePlan> Create(CreateSignaturePlanCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateSignaturePlanCommand, SignaturePlan>("SignaturePlan/Create", createCommand);
        }

        public async Task<SignaturePlan> Update(UpdateSignaturePlanCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<UpdateSignaturePlanCommand, SignaturePlan>("SignaturePlan/Update", createCommand, HttpMethod.Patch, null);
        }

        public async Task<List<SignaturePlan>> GetAll(Expression<Func<SignaturePlan, bool>> entityFilter = null, Expression<Func<SignaturePlan, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<SignaturePlan>("")
                    .For<SignaturePlan>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlan>>("SignaturePlan/GetAll", HttpMethod.Get, dic);
        }

        public async Task<SignaturePlan> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id",id }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<SignaturePlan>("SignaturePlan/GetById", HttpMethod.Get, dic);
        }
    }
}

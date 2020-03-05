using InfinitusApp.Core.Data.Commands;
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
    public class SignaturePlanApplicationUserService : ServiceBase
    {
        public SignaturePlanApplicationUserService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<SignaturePlanApplicationUser> Create(CreateSignaturePlanApplicationUserCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateSignaturePlanApplicationUserCommand, SignaturePlanApplicationUser>("SignaturePlanApplicationUser/Create", createCommand);
        }

        public async Task<List<SignaturePlanApplicationUser>> GetAll(Expression<Func<SignaturePlanApplicationUser, bool>> entityFilter = null, Expression<Func<SignaturePlanApplicationUser, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<SignaturePlanApplicationUser>("")
                    .For<SignaturePlanApplicationUser>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlanApplicationUser>>("SignaturePlanApplicationUser/GetAll", HttpMethod.Get, dic);
        }
    }
}

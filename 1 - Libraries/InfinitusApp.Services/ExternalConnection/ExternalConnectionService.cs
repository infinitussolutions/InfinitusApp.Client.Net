using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalConnection
{
    public class ExternalConnectionService : ServiceBase
    {
        public ExternalConnectionService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<InfinitusApp.Core.Data.DataModels.ExternalConnection> Create(CreateExternalConnectionCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateExternalConnectionCommand, InfinitusApp.Core.Data.DataModels.ExternalConnection>("ExternalConnection/Create", cmd, HttpMethod.Post, null);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("ExternalConnection/Delete", HttpMethod.Delete, dic);
        }

        public async Task<List<Core.Data.DataModels.ExternalConnection>> GetAllByApplicationUserId(string appUserId, Expression<Func<Core.Data.DataModels.ExternalConnection, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.ExternalConnection, object>> entityOrderBy = null, int? skip = null, int? top = null)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.ExternalConnection>("")
                    .For<Core.Data.DataModels.ExternalConnection>(x => x)
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

            dic.Add("appUserId", appUserId);

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.ExternalConnection>>("ExternalConnection/GetAllByApplicationUserId", HttpMethod.Get, dic);
        }

    }
}

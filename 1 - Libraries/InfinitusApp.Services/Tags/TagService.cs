using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Tags
{
    public class TagService : ServiceBase
    {
        public TagService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<Core.Data.DataModels.Tag> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Tag>("Tag/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Tag>> GetAll(Expression<Func<Core.Data.DataModels.Tag, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.Tag, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.Tag>("")
                   .For<Core.Data.DataModels.Tag>(x => x)
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

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Tag>>("Tag/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<Core.Data.DataModels.Tag> Update(TagUpdateCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<TagUpdateCommand, Core.Data.DataModels.Tag>("Tag/Update", cmd, HttpMethod.Patch, null);
        }
    }
}

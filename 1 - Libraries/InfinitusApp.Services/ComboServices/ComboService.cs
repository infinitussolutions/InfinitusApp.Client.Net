using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.ComboModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ComboServices
{
    public class ComboService : ServiceBase
    {
        public ComboService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Combo> Create(CreateComboCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateComboCommand, Combo>(nameof(Combo) + "/Create", cmd);
        }

        public async Task<Combo> Update(UpdateComboCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateComboCommand, Combo>(nameof(Combo) + "/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<Combo> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id",id }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<Combo>(nameof(Combo) + "/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<Combo>> GetAll(Expression<Func<Combo, bool>> entityFilter = null, Expression<Func<Combo, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<Combo>("")
                    .For<Combo>(x => x)
                    .ByList();

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
            {
                if (desc)
                    odataBuilder.OrderBy(entityOrderBy);

                else
                    odataBuilder.OrderBy(entityOrderBy);
            }

            else
                odataBuilder.OrderByDescending(x => x.CreatedAt);

            var dic = odataBuilder.ToDictionary();

            return await ServiceClient.InvokeApiAsync<List<Combo>>(nameof(Combo) + "/GetAll", HttpMethod.Get, dic);
        }
    }
}

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
    public class ComboCategoryService : ServiceBase
    {
        public ComboCategoryService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<ComboCategory> Create(CreateComboCategoryCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateComboCategoryCommand, ComboCategory>(nameof(ComboCategory) + "/Create", cmd);
        }

        public async Task<ComboCategory> Update(UpdateComboCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateComboCommand, ComboCategory>(nameof(ComboCategory) + "/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<ComboCategory> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id",id }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<ComboCategory>(nameof(ComboCategory) + "/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<ComboCategory>> GetAll(Expression<Func<ComboCategory, bool>> entityFilter = null, Expression<Func<ComboCategory, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<ComboCategory>("")
                    .For<ComboCategory>(x => x)
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

            return await ServiceClient.InvokeApiAsync<List<ComboCategory>>(nameof(ComboCategory) + "/GetAll", HttpMethod.Get, dic);
        }
    }
}

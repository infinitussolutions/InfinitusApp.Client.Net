using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static InfinitusApp.Core.Data.Enums.DataItemEnums;

namespace InfinitusApp.Services.Group
{
    public class GroupService : ServiceBase
    {
        public GroupService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<Core.Data.DataModels.Group>> GetAllByTypeWithRelations(string type)
        {
            var dic = new Dictionary<string, string>
            {
                { "type", type }
            };

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Group>>("Group/Group/GetAllByTypeWithRelations", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Group>> GetAll(Expression<Func<Core.Data.DataModels.Group, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.Group, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.Group>("")
                    .For<Core.Data.DataModels.Group>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Group>>(nameof(Core.Data.DataModels.Group) + "/Group/GetAll", HttpMethod.Get, dic);
        }

        //public async Task<List<Core.Data.DataModels.Group>> GetAllByTypeWithRelations(string dataStoreId, DataItemType type)
        //{
        //    var dic = new Dictionary<string, string>
        //    {
        //        { "dataStoreId", dataStoreId },
        //        { "type", type.ToString() }
        //    };

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Group>>("Group/Group/GetAllByTypeWithRelations", HttpMethod.Get, dic);
        //}

        //public async Task<List<Core.Data.DataModels.Group>> GetAllByDataStoreId(string dataStoreId, bool justWithDataItems = false, ODataFiltersParameter parameter = null, Expression<Func<Core.Data.DataModels.Group, object>> OrderByPropertyName = null, int skip = 0, int top = 10)
        //{
        //    var dic = new Dictionary<string, string>
        //    {
        //        { "dataStoreId", dataStoreId },
        //        { "justWithDataItems", justWithDataItems.ToString() },
        //        { "$skip", skip.ToString() },
        //        { "$top", top.ToString() }
        //    };

        //    if (parameter != null && !string.IsNullOrEmpty(parameter?.ODataFilter))
        //        dic.Add("$filter", parameter.ODataFilter);

        //    if (OrderByPropertyName != null)
        //        dic.Add("$orderby", OrderByPropertyName.OrderByExpressionToString());

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Group>>("Group/Group/GetAllByDataStoreId", HttpMethod.Get, dic);
        //}
    }
}

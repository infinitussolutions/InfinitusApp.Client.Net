using InfinitusApp.Core.Data.Commands.DataItem;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static InfinitusApp.Core.Data.DataModels.DataItemUser;

namespace InfinitusApp.Services.DataStore
{
    public class DataItemUserService : ServiceBase
    {
        public DataItemUserService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<DataItemUser> Create(DataItemUserCreateCommand command)
        {
            return await ServiceClient.InvokeApiAsync<DataItemUserCreateCommand, DataItemUser>("DataItemUser/Create", command);
        }

        public async Task<List<DataItemUser>> Create(List<DataItemUserCreateCommand> commandList)
        {
            return await ServiceClient.InvokeApiAsync<List<DataItemUserCreateCommand>, List<DataItemUser>>("DataItemUser/CreateList", commandList);
        }

        public async Task<DataItemUser> Update(DataItemUserUpdateCommand command)
        {
            return await ServiceClient.InvokeApiAsync<DataItemUserUpdateCommand, DataItemUser>("DataItemUser/Update", command, HttpMethod.Patch, null);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>()
                {
                    { "id", id },
                };

            return await ServiceClient.InvokeApiAsync<bool>("DataItemUser/Delete", HttpMethod.Delete, dic);
        }

        public async Task<List<DataItemUser>> GetAllByDataItemId(string dataItemId, DataItemUserType? relationType = null)
        {
            var dic = new Dictionary<string, string>()
                {
                    { "dataItemId", dataItemId },
                };

            if (relationType.HasValue)
                dic.Add("relationType", relationType.ToString());

            return await ServiceClient.InvokeApiAsync<List<DataItemUser>>("DataItemUser/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task<List<DataItemUser>> GetAllByApplicationUserId(string appUserId, Expression<Func<DataItemUser, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.DataItemUser, object>> OrderByPropertyName = null, int skip = 0, int top = 10)
        {
            //var dic = new Dictionary<string, string>()
            //{
            //    { "appUserId", appUserId },
            //    { "$skip", skip.ToString() },
            //    { "$top", top.ToString() }
            //};

            //if (parameter != null && !string.IsNullOrEmpty(parameter?.ODataFilter))
            //    dic.Add("$filter", parameter.ODataFilter);

            //if (OrderByPropertyName != null)
            //    dic.Add("$orderby", OrderByPropertyName.OrderByExpressionToString());

            var odataBuilder = new ODataQueryBuilder<DataItemUser>("")
                  .For<DataItemUser>(x => x)
                  .ByList()
                  .Top(top)
                  .Skip(skip)
                  ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (OrderByPropertyName != null)
            {
                odataBuilder.OrderByDescending(OrderByPropertyName);
            }

            else
                odataBuilder.OrderBy(x => x.CreatedAt);

            var dic = odataBuilder.ToDictionary();

            dic.Add("appUserId", appUserId);

            //if (relationType.HasValue)
            //    dic.Add("RelationType", relationType.ToString());

            //if (relationType.HasValue)
            //    dic.Add("relationType", relationType.ToString());

            return await ServiceClient.InvokeApiAsync<List<DataItemUser>>("DataItemUser/GetAllByApplicationUserId", HttpMethod.Get, dic);
        }

        public async Task<List<DataItemUser>> GetAllByApplicationUserIdAndDataItemId(string appUserId, string dataItemId, DataItemUserType? relationType = null)
        {
            var dic = new Dictionary<string, string>()
                {
                    { "appUserId", appUserId },
                    { "dataItemId", dataItemId },
                };

            if (relationType.HasValue)
                dic.Add("relationType", relationType.ToString());

            return await ServiceClient.InvokeApiAsync<List<DataItemUser>>("DataItemUser/GetAllByApplicationUserIdAndDataItemId", HttpMethod.Get, dic);
        }
    }
}

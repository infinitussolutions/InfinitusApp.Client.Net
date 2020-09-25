using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.Commands.Agenda;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static InfinitusApp.Core.Data.Enums.DataItemEnums;
using OData.QueryBuilder.Builders;
using InfinitusApp.Services.Address;

namespace InfinitusApp.Services.DataItem
{
    public class DataItemService : ServiceBase
    {
        public DataItemService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<Core.Data.DataModels.DataItem>> GetAllByDataStoreId(string dataStoreId, Expression<Func<Core.Data.DataModels.DataItem, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.DataItem, object>> entityOrderBy = null, int skip = 0, int top = 10, bool desc = false, string filterString = null)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.DataItem>("")
                    .For<Core.Data.DataModels.DataItem>(x => x)
                    .ByList()
                    .Top(top)
                    .Skip(skip)
                    ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
            {
                if (desc)
                    odataBuilder.OrderByDescending(entityOrderBy);

                else
                    odataBuilder.OrderBy(entityOrderBy);
            }

            else
                odataBuilder.OrderByDescending(x => x.CreatedAt);

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);

            if (entityFilter == null && !string.IsNullOrEmpty(filterString))
                dic.Add("$filter", filterString);

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.DataItem>> GetAllSimple(Expression<Func<Core.Data.DataModels.DataItem, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.DataItem, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.DataItem>("")
                    .For<Core.Data.DataModels.DataItem>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllSimple", HttpMethod.Get, dic);
        }

        public async Task<List<DataItemAddressResult>> GetAllDataItemByLocation(double latitude, double longitude, string dataItemType = "", string groupId = "", string tagId = "", bool onlyTakeAway = false, bool onlyBooking = false, string q = "", int skip = 0, int top = 10)
        {
            var dic = new Dictionary<string, string>
            {
                { "$skip", skip.ToString() },
                { "$top", top.ToString() },
                {"latitude",latitude.ToString().Replace(",",".") },
                {"longitude",longitude.ToString().Replace(",",".") }
            };

            if (!string.IsNullOrEmpty(dataItemType))
                dic.Add("dataItemType", dataItemType.ToString());

            if (!string.IsNullOrEmpty(groupId))
                dic.Add("groupId", groupId.ToString());

            if (!string.IsNullOrEmpty(tagId))
                dic.Add("tagId", tagId);

            if (onlyTakeAway)
                dic.Add("onlyTakeAway", onlyTakeAway.ToString());

            if (onlyBooking)
                dic.Add("onlyBooking", onlyBooking.ToString());

            if (!string.IsNullOrEmpty(q))
                dic.Add("q", q);

            return await ServiceClient.InvokeApiAsync<List<DataItemAddressResult>>("DataItem/GetAllDataItemByLocation", HttpMethod.Get, dic);
        }


        //public async Task<List<Core.Data.DataModels.DataItem>> GetAllByDataStoreId(string dataStoreId, ODataFiltersParameter parameter = null, Expression<Func<Core.Data.DataModels.DataItem, object>> OrderByPropertyName = null, int skip = 0, int top = 10, bool desc = false)
        //{
        //    var dic = new Dictionary<string, string>
        //    {
        //        { "dataStoreId", dataStoreId },
        //        { "$skip", skip.ToString() },
        //        { "$top", top.ToString() }
        //    };

        //    if (parameter != null && !string.IsNullOrEmpty(parameter?.ODataFilter))
        //        dic.Add("$filter", parameter.ODataFilter);

        //    if (OrderByPropertyName != null)
        //    {
        //        var order = OrderByPropertyName.OrderByExpressionToString();

        //        if (desc)
        //            order += " desc";

        //        dic.Add("$orderby", order);
        //    }

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllByDataStoreId", HttpMethod.Get, dic);
        //}



        public async Task<List<Core.Data.DataModels.DataItem>> Find(string dataStoreId, string q)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId },
                { "q", q },
                { "$skip", 0.ToString() },
                { "$top", 3.ToString() }
            };

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/Find", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.DataItem>> GetAllByTagId(string tagId, Expression<Func<Core.Data.DataModels.DataItem, bool>> filter = null, Expression<Func<Core.Data.DataModels.DataItem, object>> OrderByPropertyName = null, int skip = 0, int top = 10, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.DataItem>("")
                   .For<Core.Data.DataModels.DataItem>(x => x)
                   .ByList()
                   .Top(top)
                   .Skip(skip)
                   ;

            if (OrderByPropertyName != null)
            {
                if (desc)
                    odataBuilder.OrderByDescending(OrderByPropertyName);

                else
                    odataBuilder.OrderBy(OrderByPropertyName);
            }

            else
                odataBuilder.OrderByDescending(x => x.CreatedAt);

            if (filter != null)
                odataBuilder.Filter(filter);

            var dic = odataBuilder.ToDictionary();

            dic.Add("tagId", tagId);

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllByTagId", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.DataItem>> GetAllByCollaboratorEmail(string dataStoreId, string email, Expression<Func<Core.Data.DataModels.DataItem, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.DataItem, object>> OrderByPropertyName = null, int skip = 0, int top = 10)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.DataItem>("")
                   .For<Core.Data.DataModels.DataItem>(x => x)
                   .ByList()
                   .Top(top)
                   .Skip(skip)
                   ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (OrderByPropertyName != null)
            {
                odataBuilder.OrderBy(OrderByPropertyName);
            }

            else
                odataBuilder.OrderByDescending(x => x.CreatedAt);

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);
            dic.Add("email", email);

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllByCollaboratorEmail", HttpMethod.Get, dic);
        }

        public async Task<int> GetAllByCollaboratorEmailCount(string dataStoreId, string email, string dataItemType = "")
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId },
                { "email", email },
                { "type", dataItemType }
            };

            return await ServiceClient.InvokeApiAsync<int>("DataItem/GetAllByCollaboratorEmailCount", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Group>> GetAllGroupHasDataItemByDataStoreId(string dataStoreId, string groupDataItemType = "", int skip = 0, int top = 10)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId },
                { "groupDataItemType", groupDataItemType },
                { "$skip", skip.ToString() },
                { "$top", top.ToString() }
            };

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Group>>("DataItem/GetAllGroupHasDataItemByDataStoreId", HttpMethod.Get, dic);
        }

        //public async Task<List<Core.Data.DataModels.DataItem>> GetAllDataItems(string dataStoreId, DataItemType? dataItemType = null, bool justVisible = false)
        //{
        //    var dic = new Dictionary<string, string>
        //    {
        //        { "dataStoreId", dataStoreId },
        //        { "justVisible", justVisible.ToString() }
        //    };

        //    if (dataItemType != null)
        //    {
        //        var type = Enum.GetName(typeof(DataItemType), dataItemType);
        //        dic.Add("type", type);
        //    }

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllDataItemsByType", HttpMethod.Get, dic);
        //}

        //public async Task<List<Core.Data.DataModels.DataItem>> GetAllDataItemsShowInFeed(string dataStoreId)
        //{
        //    var dic = new Dictionary<string, string>
        //        {
        //            { "dataStoreId", dataStoreId }
        //        };

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllDataItemsShowInFeed", HttpMethod.Get, dic);
        //}

        //public async Task<List<Core.Data.DataModels.DataItem>> GetAllDataItemsShowInFeedPaid(string dataStoreId)
        //{
        //    var dic = new Dictionary<string, string>
        //        {
        //            { "dataStoreId", dataStoreId }
        //        };

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllDataItemsShowInFeedPaid", HttpMethod.Get, dic);
        //}

        //public async Task<List<Core.Data.DataModels.DataItem>> GetDataItemsByParent(string dataStoreId, string parentId = null)
        //{
        //    var dic = new Dictionary<string, string>();
        //    dic.Add("dataStoreId", dataStoreId);

        //    if (parentId != null)
        //    {
        //        dic.Add("parentId", parentId);
        //    }

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllByLevel", HttpMethod.Get, dic);
        //}

        public async Task<Core.Data.DataModels.DataItem> GetDataItemById(string dataItemId)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", dataItemId }
                };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.DataItem>("DataItem/GetById", HttpMethod.Get, dic);
        }

        public async Task<Core.Data.DataModels.DataItem> GetDataItemByIdSimple(string dataItemId)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", dataItemId }
                };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.DataItem>("DataItem/GetByIdSimple", HttpMethod.Get, dic);
        }


        private async Task<Core.Data.DataModels.DataItem> Create(Core.Data.DataModels.DataItem dataItem)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<Core.Data.DataModels.DataItem, Core.Data.DataModels.DataItem>("DataItem/Create", dataItem);
        }

        public async Task<Core.Data.DataModels.DataItem> CreateByCommand(CreateDataItemCommand command)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<CreateDataItemCommand, Core.Data.DataModels.DataItem>("DataItem/CreateByCommand", command);
        }

        public async Task<Core.Data.DataModels.DataItem> UpdateByCommand(UpdateDataItemCommand command)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<UpdateDataItemCommand, Core.Data.DataModels.DataItem>("DataItem/UpdateByCommand", command, HttpMethod.Patch, null);
        }

        public async Task<Core.Data.DataModels.DataItem> Update(Core.Data.DataModels.DataItem dataItem)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<Core.Data.DataModels.DataItem, Core.Data.DataModels.DataItem>("DataItem/Update", dataItem, HttpMethod.Patch, null);
        }

        public async Task<Core.Data.DataModels.DataItem> Save(Core.Data.DataModels.DataItem dataItem)
        {
            if (string.IsNullOrEmpty(dataItem.Id))
                return await Create(dataItem);

            else
                return await Update(dataItem);
        }

        //public async Task<List<Core.Data.DataModels.DataItem>> GetAllByApplicationUserId(string dataStoreId, string appUserId)
        //{
        //    var dic = new Dictionary<string, string>
        //        {
        //            { "dataStoreId", dataStoreId },
        //            { "appUserId", appUserId }
        //        };

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllByApplicationUserId", HttpMethod.Get, dic);
        //}



        //public async Task<List<Core.Data.DataModels.DataItem>> GetAllEventByEmail(string email)
        //{
        //    var dic = new Dictionary<string, string>
        //        {
        //            { "email", email }
        //        };

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllEventByEmail", HttpMethod.Get, dic);
        //}

        public async Task<List<TimeBox>> GetTimeBoxes(TimeBoxCommand cmd)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<TimeBoxCommand, List<Core.Data.DataModels.TimeBox>>("DataItem/GetTimeBoxes", cmd);
        }

        //public async Task<List<Core.Data.DataModels.DataItem>> GetAllByGroupId(string groupId)
        //{
        //    var dic = new Dictionary<string, string>
        //        {
        //            { "groupId", groupId }
        //        };

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllByGroupId", HttpMethod.Get, dic);
        //}

        //public async Task<List<Core.Data.DataModels.DataItem>> GetAllBySubGroupId(string subGroupId)
        //{
        //    var dic = new Dictionary<string, string>
        //        {
        //            { "subGroupId", subGroupId }
        //        };

        //    return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.DataItem>>("DataItem/GetAllBySubGroupId", HttpMethod.Get, dic);
        //}
    }
}
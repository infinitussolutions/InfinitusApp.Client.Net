﻿using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.FInancial
{
    public class FinancialRequestService : ServiceBase
    {
        public FinancialRequestService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<FinancialRequest> Create(CreateFinancialRequestCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateFinancialRequestCommand, FinancialRequest>("FinancialRequest/Create", createCommand);
        }

        public async Task<FinancialRequest> Update(UpdateFinancialRequestCommand updateCommand)
        {
            return await ServiceClient.InvokeApiAsync<UpdateFinancialRequestCommand, FinancialRequest>("FinancialRequest/Update", updateCommand, HttpMethod.Patch, null);
        }

        public async Task<List<FinancialRequest>> GetAllByDataStoreId(string dataStoreId, string customerEmail = "", Expression<Func<FinancialRequest, bool>> entityFilter = null, int skip = 0, int top = 10)
        {
            var odataBuilder = new ODataQueryBuilder<FinancialRequest>("")
                 .For<FinancialRequest>(x => x)
                 .ByList()
                 .Top(top)
                 .Skip(skip)
                 .OrderByDescending(x => x.CreatedAt)
                 ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);

            if (!string.IsNullOrEmpty(customerEmail))
                dic.Add("customerEmail", customerEmail);

            return await ServiceClient.InvokeApiAsync<List<FinancialRequest>>("FinancialRequest/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<List<FinancialRequest>> GetAll(string customerEmail = "", Expression<Func<FinancialRequest, bool>> entityFilter = null, Expression<Func<FinancialRequest, object>> entityOrderBy = null, int? skip = null, int? top = null, string customerName = "", string trackingCode = "", DateTime? createDate = null)
        {
            var odataBuilder = new ODataQueryBuilder<FinancialRequest>("")
               .For<FinancialRequest>(x => x)
               .ByList()
               .OrderByDescending(x => x.CreatedAt)
               ;

            var hasFilter = false;

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (entityFilter != null)
            {
                odataBuilder.Filter(entityFilter);

                hasFilter = true;
            }

            if (entityOrderBy != null)
                odataBuilder.OrderBy(entityOrderBy);

            var dic = odataBuilder.ToDictionary();

            if (!hasFilter)
            {
                var filter = string.Empty;

                if (createDate.HasValue)
                    filter = string.Format("month(CreatedAt) ge {0} and year(CreatedAt) ge {1} and day(CreatedAt) ge {2}", createDate.Value.Month, createDate.Value.Year, createDate.Value.Day);

                if (!string.IsNullOrEmpty(filter))
                    dic.Add("$filter", filter);
            }

            else
            {
                if (createDate.HasValue)
                {
                    var originalFilter = dic.FirstOrDefault(x => x.Key.Equals("$filter")).Value;

                    dic.Remove("$filter");

                    originalFilter += string.Format("and month(CreatedAt) ge {0} and year(CreatedAt) ge {1} and day(CreatedAt) ge {2}", createDate.Value.Month, createDate.Value.Year, createDate.Value.Day);

                    dic.Add("$filter", originalFilter);
                }
            }

            if (!string.IsNullOrEmpty(customerEmail))
                dic.Add("customerEmail", customerEmail);

            if (!string.IsNullOrEmpty(customerName))
                dic.Add("customerName", customerName);

            if (!string.IsNullOrEmpty(trackingCode))
                dic.Add("trackingCode", trackingCode);

            //if (createDate.HasValue)
            //    dic.Add("createDate", createDate.Value.ToString());

            return await ServiceClient.InvokeApiAsync<List<FinancialRequest>>("FinancialRequest/GetAll", HttpMethod.Get, dic);
        }

        public async Task<int> GetCount(string customerEmail = "", bool anyOpen = true)
        {
            var dic = new Dictionary<string, string>
            {
                { "anyOpen", anyOpen.ToString() }
            };

            if (!string.IsNullOrEmpty(customerEmail))
                dic.Add("customerEmail", customerEmail);

            return await ServiceClient.InvokeApiAsync<int>("FinancialRequest/GetCount", HttpMethod.Get, dic);
        }

        public async Task<FinancialRequest> GetById(string Id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", Id }
            };

            return await ServiceClient.InvokeApiAsync<FinancialRequest>("FinancialRequest/GetById", HttpMethod.Get, dic);
        }

        public async Task<string> GetDefaultSalesmanByDataStoreId(string Id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", Id }
            };

            return await ServiceClient.InvokeApiAsync<string>("DataStore/GetDefaultSalesmanByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<string> ExportRequest(string Id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", Id }
            };

            return await ServiceClient.InvokeApiAsync<string>("FinancialRequest/ExportRequest", HttpMethod.Get, dic);
        }
    }
}

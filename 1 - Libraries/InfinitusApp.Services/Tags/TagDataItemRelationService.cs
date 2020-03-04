﻿using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Tags
{
    public class TagDataItemRelationService : ServiceBase
    {
        public TagDataItemRelationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Core.Data.DataModels.TagDataItemRelation> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.TagDataItemRelation>("TagDataItemRelation/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<TagDataItemRelation>> GetAllByTagId(string tagId, Expression<Func<Core.Data.DataModels.TagDataItemRelation, bool>> entityFilter = null, int? skip = null, int? top = null, PageOrderType order = PageOrderType.Date)
        {
            var odataBuilder = new ODataQueryBuilder<TagDataItemRelation>("")
                   .For<TagDataItemRelation>(x => x)
                   .ByList()
                   ;

            switch (order)
            {
                case PageOrderType.Date:
                    odataBuilder.OrderByDescending(x => x.CreatedAt);
                    break;

                case PageOrderType.Alphabetic:
                    odataBuilder.OrderBy(x => x.DataItem.Description.Title);
                    break;
            }

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            var dic = odataBuilder.ToDictionary();

            dic.Add("tagId", tagId);

            var result = await ServiceClient.InvokeApiAsync<List<TagDataItemRelation>>("TagDataItemRelation/GetAllByTagId", HttpMethod.Get, dic);

            return result;

        }
    }
}

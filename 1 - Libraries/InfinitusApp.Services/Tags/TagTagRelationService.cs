using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Tags
{
    public class TagTagRelationService : ServiceBase
    {
        public TagTagRelationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<TagTagRelation>> GetAllByTagId(string tagId, Expression<Func<TagTagRelation, bool>> entityFilter = null, int? skip = null, int? top = null, PageOrderType order = PageOrderType.Date)
        {
            var odataBuilder = new ODataQueryBuilder<TagTagRelation>("")
                   .For<TagTagRelation>(x => x)
                   .ByList()
                   ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            var dic = odataBuilder.ToDictionary();

            switch (order)
            {
                case PageOrderType.Date:
                    dic.Add("orderby", "CreatedAt asc");
                    //   odataBuilder.OrderByDescending(x => x.CreatedAt);
                    break;

                case PageOrderType.Alphabetic:
                    dic.Add("orderby", "Tag/Presentation/InternalTitlePresentation desc");
                    //    odataBuilder.OrderBy(x => x.Tag.Presentation.InternalTitlePresentation);
                    break;
            }

            dic.Add("tagId", tagId);

            var result = await ServiceClient.InvokeApiAsync<List<TagTagRelation>>("TagTagRelation/GetAllByTagId", HttpMethod.Get, dic);

            return result;

        }
    }
}

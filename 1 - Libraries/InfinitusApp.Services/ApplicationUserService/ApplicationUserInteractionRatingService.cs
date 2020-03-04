using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ApplicationUserService
{
    public class ApplicationUserInteractionRatingService : ServiceBase
    {
        public ApplicationUserInteractionRatingService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<ApplicationUserInteractionRating> Create(ApplicationUserInteractionRatingCreateCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<ApplicationUserInteractionRatingCreateCommand, ApplicationUserInteractionRating>("ApplicationUserInteractionRating/Create", cmd);
        }

        public async Task<ApplicationUserInteractionRating> Update(ApplicationUserInteractionRatingUpdateCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<ApplicationUserInteractionRatingUpdateCommand, ApplicationUserInteractionRating>("ApplicationUserInteractionRating/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<ApplicationUserInteractionRating> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<ApplicationUserInteractionRating>("ApplicationUserInteractionRating/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<ApplicationUserInteractionRating>> GetAllByDataItemId(string dataItemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId }
            };

            return await ServiceClient.InvokeApiAsync<List<ApplicationUserInteractionRating>>("ApplicationUserInteractionRating/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task<List<ApplicationUserInteractionRating>> GetAllByDataStoreId(string dataStoreId, Expression<Func<ApplicationUserInteractionRating, bool>> entityFilter = null, Expression<Func<ApplicationUserInteractionRating, object>> OrderByPropertyName = null, int skip = 0, int top = 10)
        {
            //var dic = new Dictionary<string, string>
            //{
            //    { "dataStoreId", dataStoreId },
            //    { "$skip", skip.ToString() },
            //    { "$top", top.ToString() }
            //};

            //if (parameter != null && !string.IsNullOrEmpty(parameter?.ODataFilter))
            //    dic.Add("$filter", parameter.ODataFilter);

            //if (OrderByPropertyName != null)
            //    dic.Add("$orderby", OrderByPropertyName.OrderByExpressionToString());


            var odataBuilder = new ODataQueryBuilder<ApplicationUserInteractionRating>("")
                   .For<ApplicationUserInteractionRating>(x => x)
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

            dic.Add("dataStoreId", dataStoreId);

            return await ServiceClient.InvokeApiAsync<List<ApplicationUserInteractionRating>>("ApplicationUserInteractionRating/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<List<DataItemRatingPresentation>> GetAllDataItemRatingByDataStoreId(string dataStoreId, int skip = 0, int top = 10)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId },
                { "$skip", skip.ToString() },
                { "$top", top.ToString() }
            };

            return await ServiceClient.InvokeApiAsync<List<DataItemRatingPresentation>>("ApplicationUserInteractionRating/GetAllDataItemRatingByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

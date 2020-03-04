using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Booking
{
    public class BookingConfigurationService : ServiceBase
    {
        public BookingConfigurationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Core.Data.DataModels.BookingConfiguration> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.BookingConfiguration>("BookingConfiguration/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.BookingConfiguration>> GetAllByDataStoreId(string dataStoreId, Expression<Func<Core.Data.DataModels.BookingConfiguration, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.BookingConfiguration, object>> entityOrderBy = null, int? skip = null, int? top = null)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.BookingConfiguration>("")
                    .For<Core.Data.DataModels.BookingConfiguration>(x => x)
                    .ByList()
                    .OrderBy(x => x.CreatedAt)
                    ;

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
                odataBuilder.OrderBy(entityOrderBy);

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataStoreId", dataStoreId);

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.BookingConfiguration>>("BookingConfiguration/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

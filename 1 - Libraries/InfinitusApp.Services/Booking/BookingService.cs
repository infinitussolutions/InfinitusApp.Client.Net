using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using InfinitusApp.Services.DataItem;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Booking
{
    public class BookingService : ServiceBase
    {
        public BookingService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Core.Data.DataModels.Booking> Create(CreateBookingCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateBookingCommand, Core.Data.DataModels.Booking>("Booking/Create", cmd);
        }

        public async Task<Core.Data.DataModels.Booking> Update(UpdateBookingCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateBookingCommand, Core.Data.DataModels.Booking>("Booking/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<bool> Delete(List<string> IdsToDelete)
        {
            return await ServiceClient.InvokeApiAsync<List<string>, bool>("Booking/Delete", IdsToDelete, HttpMethod.Delete, null);
        }

        public async Task<List<Core.Data.DataModels.Booking>> GetAllByDataStoreId(string dataStoreId, Expression<Func<Core.Data.DataModels.Booking, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.Booking, object>> entityOrderBy = null, int? skip = null, int? top = null)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.Booking>("")
                    .For<Core.Data.DataModels.Booking>(x => x)
                    .ByList()
                    .OrderByDescending(x => x.CreatedAt)
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

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Booking>>("Booking/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<List<Core.Data.DataModels.Booking>> GetAllByDataItemId(string dataItemId, Expression<Func<Core.Data.DataModels.Booking, bool>> entityFilter = null, Expression<Func<Core.Data.DataModels.Booking, object>> entityOrderBy = null, int? skip = null, int? top = null)
        {
            var odataBuilder = new ODataQueryBuilder<Core.Data.DataModels.Booking>("")
                    .For<Core.Data.DataModels.Booking>(x => x)
                    .ByList()
                    .OrderByDescending(x => x.CreatedAt)
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

            dic.Add("dataItemId", dataItemId);

            return await ServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Booking>>("Booking/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task<Core.Data.DataModels.BookingConfiguration> CreateConfig(CreateBookingConfigurationCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateBookingConfigurationCommand, Core.Data.DataModels.BookingConfiguration>("BookingConfiguration/Create", cmd);
        }
    }
}

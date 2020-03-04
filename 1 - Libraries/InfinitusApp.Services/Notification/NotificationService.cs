using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Notification
{
    public class NotificationService : ServiceBase
    {
        public NotificationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<ApplicationUserNotification>> GetUserNotificationsByUserId(string id, Expression<Func<ApplicationUserNotification, bool>> entityFilter = null, int skip = 0, int top = 10)
        {
            var odataBuilder = new ODataQueryBuilder<ApplicationUserNotification>("")
                    .For<ApplicationUserNotification>(x => x)
                    .ByList()
                    .Top(top)
                    .Skip(skip)
                    .OrderByDescending(x => x.CreatedAt)
                    ;

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            var dic = odataBuilder.ToDictionary();

            dic.Add("id", id);

            var list = await ServiceClient.InvokeApiAsync<List<ApplicationUserNotification>>("Notification/GetUserNotificationsByUserId", HttpMethod.Get, dic);

            return list;
        }

        public async Task<ApplicationUserNotification> GetUserNotificationById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            var notification = await ServiceClient.InvokeApiAsync<ApplicationUserNotification>("Notification/GetuserNotificationById", HttpMethod.Get, dic);

            return notification;
        }

        public async Task<bool> MarkUserNotificationAsRead(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            await ServiceClient.InvokeApiAsync("Notification/MarkAsRead", HttpMethod.Post, dic);

            return true;
        }

        public async Task<bool> MarkAllUserNotificationAsRead(string id)
        {
            var dic = new Dictionary<string, string>
                {
                    { "userId", id }
                };
            await ServiceClient.InvokeApiAsync("Notification/MarkAllAsRead", HttpMethod.Post, dic);

            return true;
        }

        public async Task<bool> Create(InfinitusAppCreateNotificationCommand command)
        {
            return await ServiceClient.InvokeApiAsync<InfinitusAppCreateNotificationCommand, bool>("Notification/Public/Create", command);
        }
    }
}
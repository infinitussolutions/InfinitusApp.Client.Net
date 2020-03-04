using InfinitusApp.Core.Data.Commands.ExternalDependence.Slack;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Slack
{
    public class SlackWebhookService : ServiceBase
    {
        public SlackWebhookService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<bool> CreateMessage(CreateMessageCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateMessageCommand, bool>("SlackWebhook/CreateMessage", command);
        }

        public async Task<bool> CreateBugReport(CreateBugReportCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateBugReportCommand, bool>("SlackWebhook/CreateBugReport", command);
        }
    }
}

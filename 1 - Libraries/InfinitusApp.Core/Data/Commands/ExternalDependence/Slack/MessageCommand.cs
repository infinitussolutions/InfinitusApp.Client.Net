using InfinitusApp.Core.Data.DataModels.External.Slack;
using InfinitusApp.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Slack
{
    public class MessageCommand
    {
    }

    public class CreateMessageCommand : MessageCommand
    {
        public CreateMessageCommand()
        {
            ApplicationSlackWebhook = new ApplicationSlackWebhook();
            Channel = new ChannelType();
        }

        public ApplicationSlackWebhook ApplicationSlackWebhook { get; set; }

        public ChannelType Channel { get; set; }

        public string Message { get; set; }
    }

    public class CreateBugReportCommand : CreateMessageCommand
    {
        public CreateBugReportCommand()
        {
            Environment = new EnvironmentsTypes();
        }

        public EnvironmentsTypes Environment { get; set; }

        public string Project { get; set; }

        public string CompanyName { get; set; }

        public string UserName { get; set; }

        public string RequestUri { get; set; }

        public string Line { get; set; }
    }
}

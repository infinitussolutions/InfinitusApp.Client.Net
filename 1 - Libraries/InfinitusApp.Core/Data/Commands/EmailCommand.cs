using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class EmailCommand
    {
        public IList<string> ToEmailList { get; set; }
    }

    public class SendEventCreatedConfirmationCommand : EmailCommand
    {
        public string User { get; set; }

        public string EventName { get; set; }

        public string EventDate { get; set; }
    }

    public class SendInvitedAppCommand : EmailCommand
    {
        public string AppName { get; set; }

        public string LogoUri { get; set; }

        public string Content { get; set; }

        public string InvitedByUserName { get; set; }

        public string VideoApresentationLink { get; set; }

        public string AndroidLink { get; set; }

        public string IosLink { get; set; }
    }

    public class SendInvitedEventCommand : SendInvitedAppCommand
    {
        public string EventName { get; set; }

        public string EventDate { get; set; }
    }
}

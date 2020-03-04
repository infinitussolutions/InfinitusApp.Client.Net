using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class InfinitusAppCreateNotificationCommand
    {
        public InfinitusAppCreateNotificationCommand()
        {
            UsersIds = new List<string>();
            EmailsUsers = new List<string>();
        }

        public IList<string> UsersIds;

        public IList<string> EmailsUsers;

        public ApplicationNotification ApplicationNotification;

        public bool ForAllUsers { get; set; }
        public string CustomTag { get; set; }

        public InfinitusAppCreateNotificationCommand(IList<string> _usersIds, ApplicationNotification _applicationNotification) : this()
        {
            UsersIds = _usersIds;
            ApplicationNotification = _applicationNotification;
        }

    }
}

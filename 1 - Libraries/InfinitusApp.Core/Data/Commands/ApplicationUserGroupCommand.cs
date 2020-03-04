using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class ApplicationUserGroupCommand
    {

    }

    public class ApplicationUserGroupManageCommand
    {
        public ApplicationUserGroupManageCommand()
        {
            UserIds = new List<string>();
            GroupListIds = new List<string>();
        }

        public string GroupId { get; set; }
        public IList<string> UserIds { get; set; }
        public IList<string> GroupListIds { get; set; }
    }
}

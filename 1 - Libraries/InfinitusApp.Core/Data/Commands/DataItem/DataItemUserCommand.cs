using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.DataItemUser;

namespace InfinitusApp.Core.Data.Commands.DataItem
{
    public class DataItemUserCommand
    {

    }

    public class DataItemUserCreateCommand : DataItemUserCommand
    {
        public string DataItemId { get; set; }
        public string ApplicationUserId { get; set; }
        public DataItemUserType RelationType { get; set; }
    }

    public class DataItemUserUpdateCommand : DataItemUserCommand
    {
        public string Id { get; set; }
    }
}

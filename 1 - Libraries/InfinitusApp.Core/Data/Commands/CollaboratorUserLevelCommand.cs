using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.Commands
{
    public class CollaboratorUserLevelCommand
    {
        public CollaboratorUserLevelType Level { get; set; }
    }

    public class CollaboratorUserLevelCreateCommand : CollaboratorUserLevelCommand
    {
        public CollaboratorUserLevelIdentityReference IdentityReference { get; set; }

        public string Identity { get; set; }

        public string DataItemId { get; set; }
    }

    public class CollaboratorUserLevelUpdateCommand : CollaboratorUserLevelCommand
    {
        public string Id { get; set; }
    }
}

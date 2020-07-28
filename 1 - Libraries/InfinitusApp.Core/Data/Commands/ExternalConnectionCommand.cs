using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.ExternalConnection;

namespace InfinitusApp.Core.Data.Commands
{
    public class ExternalConnectionCommand
    {
        public string ReferenceId { get; set; }

        public ExternalConnectionType Type { get; set; }
    }

    public class CreateExternalConnectionCommand : ExternalConnectionCommand
    {
        public string ApplicationUserId { get; set; }
    }
}

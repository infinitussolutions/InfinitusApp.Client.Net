using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class IndicationCommand
    {
    }

    public class CreateIndicationCommand : IndicationCommand
    {
        public string ApplicationId { get; set; }

        public string ApplicationUserId { get; set; }

        public string Identity { get; set; }

        public IndicationIdentityType IndicationIdentityType { get; set; }

        public string DataItemId { get; set; }
    }
}

using InfinitusApp.Core.Data.DataModels.External.Twilio;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class ExternalAccountsCommand
    {

    }

    public class CreateExternalAccountsCommand : ExternalAccountsCommand
    {
        public string DataStoreId { get; set; }
    }

    public class UpdateExternalAccountsCommand : ExternalAccountsCommand
    {
        public string Id { get; set; }

        public TwilioAccount Twilio { get; set; }
    }
}

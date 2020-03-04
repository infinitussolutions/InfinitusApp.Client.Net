using InfinitusApp.Core.Data.DataModels.External.Twilio;
using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ExternalAccounts : EntityBase
    {
        public ExternalAccounts()
        {
            Twilio = new TwilioAccount();
        }

        public string DataStoreId { get; set; }

        public TwilioAccount Twilio { get; set; }
    }
}

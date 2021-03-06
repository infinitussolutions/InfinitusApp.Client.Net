﻿using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Twilio
{
    public class MessageCommand
    {
        public MessageCommand()
        {
            ToNumberList = new List<string>();
        }

        public string DataStoreId { get; set; }
        public string ToNumber { get; set; }
        public MessageType Type { get; set; }
        public bool ForAllUsers { get; set; }
        public IList<string> ToNumberList { get; set; }
    }

    public class CreateTwilioMessageCommand : MessageCommand
    {
        public string Body { get; set; }
    }

    public class CreateTwilioVerifyNumberSMSCommand : MessageCommand
    {
        public string IdentityCompany { get; set; } = "Infinitus Solutions";
    }
}

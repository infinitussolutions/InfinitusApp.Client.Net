using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class PhoneCommand
    {
        public PhoneCommand()
        {
            AvailableInApp = new AvailableInApp();
        }

        public string Number { get; set; }

        public string CountryCode { get; set; }

        public PhoneNumberType? PhoneNumberType { get; set; }

        public AvailableInApp AvailableInApp { get; set; }
    }

    public class CreatePhoneCommand : PhoneCommand
    {

        #region Relations

        public string ApplicationUserId { get; set; }

        public string DataItemId { get; set; }

        #endregion

        public static string Validated(CreatePhoneCommand cmd)
        {
            var msgReturn = "";

            if (string.IsNullOrEmpty(cmd.Number))
                msgReturn += "Number is null \n";


            return msgReturn;
        }
    }

    public class UpdatePhoneCommand : PhoneCommand
    {
        public string Id { get; set; }
    }
}

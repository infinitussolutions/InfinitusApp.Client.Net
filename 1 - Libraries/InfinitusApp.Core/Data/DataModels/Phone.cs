using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Phone : Naylah.Core.Entities.EntityBase
    {
        public Phone()
        {
            PhoneNumberType = PhoneNumberType.Undefined;
            AvailableInApp = new AvailableInApp();
            ApplicationUser = new ApplicationUser();
        }

        [JsonIgnore]
        public string DDD { get; set; }

        public string Number { get; set; }

        public string CountryCode { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        public AvailableInApp AvailableInApp { get; set; }

        #region Relations

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public string DataItemId { get; set; }

        #endregion

        #region Helper

        public string PhonePresentation
        {
            get
            {
                if (string.IsNullOrEmpty(Number) && string.IsNullOrEmpty(CountryCode) && string.IsNullOrEmpty(DDD))
                    return "";

                return "+" + (string.IsNullOrEmpty(CountryCode) ? "55" : CountryCode) + " " + DDD + " " + Number;
            }
        }

        #endregion
    }

    public class AvailableInApp
    {
        public bool WhatsApp { get; set; }

        public bool Telegram { get; set; }
    }

    public enum PhoneNumberType
    {
        Undefined,
        Individual,
        Residential,
        Commercial,
        ForScrap
    }
}

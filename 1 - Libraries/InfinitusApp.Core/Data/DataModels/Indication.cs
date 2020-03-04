using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Indication : Naylah.Core.Entities.EntityBase
    {
        public Indication()
        {
            Application = new Application();
            ApplicationUser = new ApplicationUser();
        }

        public string Identity { get; set; }

        public IndicationIdentityType IndicationIdentityType { get; set; }

        #region Relations

        public Application Application { get; set; }

        public string ApplicationId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        #endregion

        #region Helper

        public bool IsPhoneIdentity { get { return IndicationIdentityType == IndicationIdentityType.PhoneNumber; } }

        public bool IsEmailIdentity { get { return IndicationIdentityType == IndicationIdentityType.Email; } }

        public bool Accept { get; set; }

        public bool NotAccept { get { return !Accept; } }

        #endregion
    }

    public enum IndicationIdentityType
    {
        Email,
        PhoneNumber
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ApplicationUserBase : Person
    {
        public ApplicationUserBase()
        {
            SocialMedia = new SocialMedia();
        }

        public string UserName { get; set; }

        public bool Active { get; set; }

        public string ApplicationId { get; set; }

        public string DocumentIdentifier { get; set; }

        public SocialMedia SocialMedia { get; set; }

        public DateTime BirthDay { get; set; } = DateTime.Now;

        public string BirthDatePresentation { get { return (BirthDay.Equals(DateTime.MinValue) || BirthDay.Date == DateTime.Now.Date) ? "" : "🎂 Data de Nascimento: " + BirthDay.ToString("dd/MM/yy"); } }
    }

    public class ApplicationUser : ApplicationUserBase
    {
        public ApplicationUser()
        {
            Phone = new PhoneComplex();
            BillingAddress = new AddressComplex();
            Notifications = new List<ApplicationUserNotification>();
            Indications = new List<Indication>();
            CustomProperties = new ApplicationUserProperties();
            Groups = new List<ApplicationUserGroup>();
            DataItems = new List<DataItem>();
            //Phones = new List<Phone>();
            TermsOfUseAccepteds = new List<TermsOfUseAccepted>();
            Addresses = new List<Address>();
            ExternalConnections = new List<ExternalConnection>();
            FinancialRequestToDeliveryList = new List<FinancialRequest>();
            FinancialRequestToPurchasesList = new List<FinancialRequest>();
            BookingList = new List<Booking>();
            CustomerZoneRelations = new List<CustomerZoneRelation>();
        }

        public PhoneComplex Phone { get; set; }

        public AddressComplex BillingAddress { get; set; }

        public ApplicationBase Application { get; set; }

        public ApplicationUserProperties CustomProperties { get; set; }

        public IList<ApplicationUserNotification> Notifications { get; set; }

        public IList<ApplicationUserGroup> Groups { get; set; }

        public UserStatus Status { get; set; }

        public DateTime LastAccess { get; set; }

        //public float Latitude { get; set; }

        //public float Longitude { get; set; }
        /// <summary>
        /// External Login
        /// </summary>
        public string Registration { get; set; }

        public IList<DataItem> DataItems { get; set; }

        //public IList<Phone> Phones { get; set; }

        public IList<TermsOfUseAccepted> TermsOfUseAccepteds { get; set; }

        public IList<Indication> Indications { get; set; }

        public IList<Address> Addresses { get; set; }

        public IList<ExternalConnection> ExternalConnections { get; set; }

        public IList<FinancialRequest> FinancialRequestToDeliveryList { get; set; }

        public IList<FinancialRequest> FinancialRequestToPurchasesList { get; set; }

        public IList<Booking> BookingList { get; set; }

        public CustomerZone CustomerZone { get; set; }
        public string CustomerZoneId { get; set; }

        public IList<CustomerZoneRelation> CustomerZoneRelations { get; set; }

        #region Enum
        public enum UserStatus
        {
            active,
            inactive,
            blocked
        }

        public enum ApplicationUserRelationshipType
        {
            None,
            Contact,
            Friend,
            Crush,
            Love
        }

        public enum ApplicationUserRelationshipStatus
        {
            Requested,
            Accepted,
            Refused,
            Blocked
        }

        #endregion

        #region Helpers

        [JsonIgnore]
        public string ApplicationUserPresentation
        {
            get
            {
                var text = "";

                if (string.IsNullOrEmpty(Id))
                    return text;

                text += "👤 Nome: " + FirstName + " " + LastName + "\n";
                text += !string.IsNullOrEmpty(DocumentIdentifier) ? "📝 Documento: " + DocumentIdentifier + "\n" : "";

                if (!string.IsNullOrEmpty(Phone?.FullPhone))
                    text += "📱 Fone: " + Phone?.FullPhone;

                return text;
            }
        }

        #endregion
    }

    public class ApplicationUserProperties
    {
        public ApplicationUserProperties()
        {
        }

        public bool Associated { get; set; }

        public string Password { get; set; }

        public string Unity { get; set; }
    }
}
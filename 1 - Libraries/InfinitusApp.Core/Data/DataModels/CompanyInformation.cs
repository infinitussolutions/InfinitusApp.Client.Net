namespace InfinitusApp.Core.Data.DataModels
{
    public class CompanyInformation
    {
        public CompanyInformation()
        {
            Address = new AddressComplex();
            Phone = new PhoneComplex();
            WhatsappBusiness = new PhoneComplex();
        }

        public string Description { get; set; }

        public string Email { get; set; }

        public string WebSiteUri { get; set; }

        public string VideoUri { get; set; }

        public AddressComplex Address { get; set; }

        public PhoneComplex Phone { get; set; }

        public PhoneComplex WhatsappBusiness { get; set; }

        public string CompanyId { get; set; }

        public string SubscriptionId { get; set; }
    }
}
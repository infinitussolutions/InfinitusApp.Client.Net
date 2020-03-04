namespace InfinitusApp.Core.Data.DataModels
{
    public class Customer : Person
    {
        public Customer()
        {
            Phone = new PhoneComplex();
            Address = new AddressComplex();
            LegalEntityInfo = new LegalEntityInfo();
            new Person();
        }

        public string IdentityDocument { get; set; }

        public PhoneComplex Phone { get; set; }

        public AddressComplex Address { get; set; }

        public LegalEntityInfo LegalEntityInfo { get; set; }

        public string NationalID { get; set; }

        public bool Edited { get; set; } = false;

        #region Relations

        public string DataStoreId { get; set; }

        #endregion Relations

    }
}
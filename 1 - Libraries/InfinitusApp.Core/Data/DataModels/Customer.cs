using InfinitusApp.Core.Extensions;

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

        public string ErrorMsg 
        {
            get
            {
                var errorMsg = string.Empty;

                if (string.IsNullOrEmpty(FirstName))
                    errorMsg += "Nome inválido\n";

                if (string.IsNullOrEmpty(Email) || !Email.Contains("@"))
                    errorMsg += "Email inválido\n";

                if (!IdentityDocument.IsCPF() && !IdentityDocument.IsCNPJ())
                    errorMsg += "Documento inválido\n";

                return errorMsg;
            }
        }
        public bool IsValid 
        {
            get
            {
                return string.IsNullOrEmpty(ErrorMsg);
            }
        }
    }
}
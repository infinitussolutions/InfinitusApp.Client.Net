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

        public string ContactName { get; set; }

        public CustomerFinancialStatus FinancialStatus { get; set; }

        #region Relations

        public string DataStoreId { get; set; }

        public CustomerType CustomerType { get; set; }

        public string CustomerTypeId { get; set; }

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
                    errorMsg += "CPF / CNPJ inválido\n";

                if (Address == null || !Address.IsValid)
                    errorMsg += "Endereço inválido\n";

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

        public bool IsCNPJ 
        {
            get
            {
                if (string.IsNullOrEmpty(IdentityDocument))
                    return false;

                return IdentityDocument.IsCNPJ();
            }
        }

        public bool IsCPF
        {
            get
            {
                if (string.IsNullOrEmpty(IdentityDocument))
                    return false;

                return IdentityDocument.IsCPF();
            }
        }

        public string DocumentPresentation
        {
            get
            {
                if (string.IsNullOrEmpty(IdentityDocument))
                    return string.Format("Documento: Não informado");

                var document = string.Format("Documento: {0}", IsCPF ? IdentityDocument.ToCPF() : IdentityDocument.ToCNPJ());

                return document;
            }
        }

        public string InscriptionPresentation
        {
            get
            {
                if (string.IsNullOrEmpty(LegalEntityInfo.StateRegistration))
                    return string.Format("Inscrição: Não informado");

                return string.Format("Inscrição: {0}", LegalEntityInfo.StateRegistration);
            }
        }

        public string ContactPresentation 
        {
            get
            {
                return string.Format("Contato: {0}", ContactName);
            }
        }

        public enum CustomerFinancialStatus
        {
            Unknown = -1,
            Ok = 1,
            NotOk = 2
        }
    }
}
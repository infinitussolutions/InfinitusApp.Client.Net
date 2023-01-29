using InfinitusApp.Core.Data.DataModels;
using static InfinitusApp.Core.Data.DataModels.Customer;

namespace InfinitusApp.Core.Data.Commands
{
    public class CustomerCommand
    {
        public CustomerCommand()
        {
            Person = new Person();
            Phone = new PhoneComplex();
            Address = new AddressComplex();
            LegalEntityInfo = new LegalEntityInfo();
        }

        public string IdentityDocument { get; set; }
        public Person Person { get; set; }
        public PhoneComplex Phone { get; set; }
        public AddressComplex Address { get; set; }

        public LegalEntityInfo LegalEntityInfo { get; set; }

        public string ContactName { get; set; }

        public string CustomerTypeId { get; set; }

        public string CustomerClassId { get; set; }

        public CustomerFinancialStatus FinancialStatus { get; set; }

        public string SalesmanEmail { get; set; }

        public string CustomerZoneId { get; set; }
    }

    public class CreateCustomerCommand : CustomerCommand
    {
        public string DataStoreId { get; set; }

        public static CreateCustomerCommand ConvertFromApplicationUser(ApplicationUser applicationUser, string dataStoreId)
        {
            var objReturn = new CreateCustomerCommand();

            if (applicationUser == null)
                return objReturn;

            objReturn.Address = applicationUser?.BillingAddress;
            objReturn.Person = applicationUser;
            objReturn.Phone = applicationUser?.Phone;
            objReturn.DataStoreId = dataStoreId;


            return objReturn;
        }
    }

    public class UpdateCustomerCommand : CustomerCommand
    {
        public string Id { get; set; }
    }
}

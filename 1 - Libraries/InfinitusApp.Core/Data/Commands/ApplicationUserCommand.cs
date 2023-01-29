using InfinitusApp.Core.Data.DataModels;
using System;
using static InfinitusApp.Core.Data.DataModels.ApplicationUser;

namespace InfinitusApp.Core.Data.Commands
{
    public class ApplicationUserCommandBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Active { get; set; }

        public string DocumentIdentifier { get; set; }

        public string Email { get; set; }

        public string ApplicationId { get; set; }

        public string PhoneNumber { get; set; }

        public string IDD { get; set; }
        public string DDD { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Building { get; set; }

        public string Number { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string ImageUri { get; set; }

        public ApplicationUserProperties CustomProperties { get; set; }

        public UserStatus? Status { get; set; }

        public string Registration { get; set; }

        public DateTime? BirthDay { get; set; }

        public SocialMedia SocialMedia { get; set; }

        public AddressComplex BillingAddress { get; set; }

        public string CustomerZoneId { get; set; }
    }

    public class CreateApplicationUserCommand : ApplicationUserCommandBase
    {
        public string UserName { get; set; }
    }

    public class UpdateApplicationUserCommand : ApplicationUserCommandBase
    {
        public UpdateApplicationUserCommand(string _applicationUserId)
        {
            Id = _applicationUserId;
        }

        public string Id { get; set; }
    }
}

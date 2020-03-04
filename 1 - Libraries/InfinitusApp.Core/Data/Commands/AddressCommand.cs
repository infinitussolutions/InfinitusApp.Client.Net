using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class AddressCommand
    {
        public AddressCommand()
        {
            Location = new Location();
        }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Building { get; set; }

        public string Number { get; set; }

        public string NumberComplement { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string CountyCode { get; set; }

        public string StateProvince { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string IdentityName { get; set; }

        public string ReferencePoint { get; set; }

        public Location Location { get; set; }
    }

    public class CreateAddressCommand : AddressCommand
    {
        public string ApplicationUserId { get; set; }

        public string DataItemId { get; set; }

        public string DataStoreId { get; set; }

        public static CreateAddressCommand FromAddress(Address address)
        {
            return new CreateAddressCommand
            {
                AddressLine1 = address?.AddressLine1,
                AddressLine2 = address?.AddressLine2,
                ApplicationUserId = address?.ApplicationUserId,
                Building = address?.Building,
                City = address?.City,
                Country = address?.Country,
                CountyCode = address?.CountyCode,
                District = address?.District,
                Location = address?.Location,
                Number = address?.Number,
                NumberComplement = address.NumberComplement,
                PostalCode = address?.PostalCode,
                StateProvince = address?.StateProvince,
                ReferencePoint = address?.ReferencePoint,
                IdentityName = address?.IdentityName,
                DataStoreId = address?.DataStoreId,
                DataItemId = !string.IsNullOrEmpty(address?.DataItemId) ? address.DataItemId : null
            };
        }
    }

    public class UpdateAddressCommand : AddressCommand
    {
        public string Id { get; set; }
        public bool Deleted { get; set; } = false;

        public static UpdateAddressCommand FromAddress(Address address)
        {
            return new UpdateAddressCommand
            {
                AddressLine1 = address?.AddressLine1,
                AddressLine2 = address?.AddressLine2,
                Id = address.Id,
                Building = address?.Building,
                City = address?.City,
                Country = address?.Country,
                CountyCode = address?.CountyCode,
                District = address?.District,
                Location = address?.Location,
                Number = address?.Number,
                NumberComplement = address?.NumberComplement,
                PostalCode = address?.PostalCode,
                StateProvince = address?.StateProvince,
                IdentityName = address?.IdentityName,
                ReferencePoint = address?.ReferencePoint,
                Deleted = address.Deleted
            };
        }
    }
}

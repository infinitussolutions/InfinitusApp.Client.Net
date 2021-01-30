using InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu;
using InfinitusApp.Core.Extensions;
using Newtonsoft.Json;
using System;

namespace InfinitusApp.Core.Data.DataModels
{
    
    public class AddressComplex
    {
        public AddressComplex()
        {
            Location = new Location();
        }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string Building { get; set; }
        public string Number { get; set; }

        public string District { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }

        public string PostalCode { get; set; }

        public Location Location { get; set; }

        [Obsolete("Use location property")]
        public double? Longitude { get; set; }

        [Obsolete("Use location property")]
        public double? Latitude { get; set; }

        [Obsolete("Use location property")]
        public double? Altitude { get; set; }

        public string FullAddress
        {
            get
            {
                return string.Format("{0}, {1} - {2}, {3} - {4} ({5})",
                    AddressLine1, 
                    Number,
                    District,
                    City,
                    StateProvince,
                    PostalCode
                    );

               // return AddressLine1 + ", " + Number + " - " + Building + " " + City + "-" + StateProvince;
            }
        }

        public string StateWithCity
        {
            get
            {
                return string.Format("{0}/{1}", City, StateProvince);
            }
        }

        public AddressModel ConvertToAddressModel(AddressComplex address)
        {
            return new AddressModel
            {
                City = address.City,
                Country = address.Country,
                District = address.District,
                Number = address.Number,
                State = address.StateProvince,
                Street = address.AddressLine1,
                ZipCode = address.PostalCode
            };
        }

        public bool IsValid 
        {
            get
            {
                if (
                string.IsNullOrEmpty(AddressLine1)
                || string.IsNullOrEmpty(PostalCode)
                || string.IsNullOrEmpty(District)
                || string.IsNullOrEmpty(City)
                || string.IsNullOrEmpty(Number)
                || string.IsNullOrEmpty(StateProvince)
                || !PostalCode.IsCEP()
                )
                    return false;

                return true;
            }
        }

        public string PostalCodePresentation
        {
            get
            {
                return string.Format("CEP: ", PostalCode);
            }
        }

        public string AddressLinePresentation
        {
            get
            {
                return string.Format("Endereço: ", AddressAndNumber);
            }
        }

        public string CityPresentation
        {
            get
            {
                return string.Format("Cidade: ", City);
            }
        }

        public string StatePresentation
        {
            get
            {
                return string.Format("UF: ", StateProvince);
            }
        }
    }

    public static class AddressComplexExtensions
    {
        public static Address ToAddress(this AddressComplex a)
        {
            return new Address
            {
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                City = a.City,
                Country = a.Country,
                District = a.District,
                Number = a.Number,
                PostalCode = a.PostalCode,
                StateProvince = a.StateProvince,
                Location = a.Location,
                Building = a.Building

            };
        }

        public static AddressModel ToAddressModel(this AddressComplex a)
        {
            return new AddressModel
            {
                City = a.City,
                Country = a.Country,
                District = a.District,
                Number = a.Number,
                State = a.StateProvince,
                Street = a.AddressLine1,
                ZipCode = a.PostalCode
            };
        }
    }
}
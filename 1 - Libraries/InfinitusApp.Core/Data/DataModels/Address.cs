using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Address : Naylah.Core.Entities.EntityBase
    {
        public Address()
        {
            Location = new Location();
            ApplicationUser = new ApplicationUser();
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

        #region Relations

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public DataItem DataItem { get; set; }

        public string DataItemId { get; set; }

        public string DataStoreId { get; set; }

        #endregion

        #region Helper

        public string FullAddressSimple
        {
            get
            {
                var full = AddressLine1;

                if (!string.IsNullOrEmpty(Number)) { full += ", " + Number + "\n"; }
                if (!string.IsNullOrEmpty(NumberComplement)) { full += "Complemento: " + NumberComplement + "\n"; }
                if (!string.IsNullOrEmpty(AddressLine2)) { full += "" + AddressLine2 + "\n"; }

                if (!string.IsNullOrEmpty(Building)) { full += "" + Building + "\n"; }
                if (!string.IsNullOrEmpty(District)) { full += "" + District + "\n"; }
                if (!string.IsNullOrEmpty(City)) { full += "" + City + " - "; }


                return full;
            }
        }

        public string FullAddress
        {
            get
            {
                var full = FullAddressSimple;
                if (!string.IsNullOrEmpty(StateProvince)) { full += "" + StateProvince + "\n"; }
                if (!string.IsNullOrEmpty(Country)) { full += "" + Country + " - "; }
                if (!string.IsNullOrEmpty(PostalCode)) { full += "" + PostalCode + "\n"; }

                return full;
            }
        }

        public string AddressAndNumber
        {
            get
            {
                var returnAddress = AddressLine1;

                if (!string.IsNullOrEmpty(Number))
                    returnAddress += ", " + Number;

                return returnAddress;
            }
        }

        public string CityAndState { get { return City + "-" + StateProvince; } }

        public bool IsPreference { get; set; }

        public bool IsActualLocation { get; set; }

        #endregion

        #region Presentation

        public string FullAddressPresentation
        {
            get
            {
                var returnAddress = AddressLine1;

                if (!string.IsNullOrEmpty(Number))
                    returnAddress += ", " + Number;

                if (!string.IsNullOrEmpty(District))
                    returnAddress += " - " + District;

                if (!string.IsNullOrEmpty(City))
                    returnAddress += " - " + City;

                return returnAddress;
            }
        }

        public string SimpleAddressWithIdentity
        {
            get
            {
                var returnAddress = AddressLine1;

                if (!string.IsNullOrEmpty(IdentityName))
                    returnAddress = "(" + IdentityName + ") " + AddressLine1;

                if (!string.IsNullOrEmpty(Number))
                    returnAddress += ", " + Number;

                //if (!string.IsNullOrEmpty(City))
                //    returnAddress += " - " + City;

                //if (returnAddress.Length > 40)
                //    returnAddress = returnAddress.Substring(0, 40) + "...";

                return returnAddress;
            }
        }

        

        #endregion
    }

    public static class AddressExtensions
    {
        public static AddressComplex ToComplex(this Address a)
        {
            return new AddressComplex
            {
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                City = a.City,
                Country = a.Country,
                District = a.District,
                Number = a.Number,
                PostalCode = a.PostalCode,
                StateProvince = a.StateProvince,
                Altitude = a.Location?.Altitude,
                Longitude = a.Location?.Longitude,
                Latitude = a.Location?.Latitude
            };
        }
    }

    public class Location
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Altitude { get; set; }
    }
}

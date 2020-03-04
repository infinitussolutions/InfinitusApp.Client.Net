using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Location
{
    public class ViaCepResponse
    {
        [JsonProperty("cep")]
        public string PostalCode { get; set; }
        [JsonProperty("logradouro")]
        public string AddressLine1 { get; set; }
        [JsonProperty("complemento")]
        public string AddressLine2 { get; set; }
        [JsonProperty("bairro")]
        public string District { get; set; }
        [JsonProperty("localidade")]
        public string City { get; set; }
        [JsonProperty("uf")]
        public string StateProvince { get; set; }
        [JsonProperty("erro")]
        public bool Error { get; set; }

        public static Address ToInfinitusAddress(ViaCepResponse model, Address address = null)
        {
            return new Address
            {
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                District = model.District,
                City = model.City,
                StateProvince = model.StateProvince,
                Country = "Brasil",
                CountyCode = "BR",
                IdentityName = !string.IsNullOrEmpty(address?.IdentityName) ? address?.IdentityName : string.Empty,
                DataItemId = !string.IsNullOrEmpty(address?.DataItemId) ? address.DataItemId : string.Empty,
                ApplicationUserId = !string.IsNullOrEmpty(address?.ApplicationUserId) ? address.ApplicationUserId : string.Empty,
                IsPreference = address != null ? address.IsPreference : false,
                Id = !string.IsNullOrEmpty(address?.Id) ? address.Id : string.Empty
            };
        }

        public static AddressComplex ToInfinitusAddressComplex(ViaCepResponse m)
        {
            return new AddressComplex
            {
                AddressLine1 = m.AddressLine1,
                AddressLine2 = m.AddressLine2,
                City = m.City,
                Country = "Brasil",
                PostalCode = m.PostalCode,
                StateProvince = m.StateProvince,
                District = m.District,
            };
        }
    }
}

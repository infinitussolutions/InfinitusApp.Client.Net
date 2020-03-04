using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    public class BionosticMedic
    {
        [JsonProperty("med_id")]
        public string Id { get; set; }
        [JsonProperty("med_nome")]
        public string Name { get; set; }
        [JsonProperty("med_data_nasc")]
        public string DateOfBirth { get; set; }
        [JsonProperty("med_crmv")]
        public string MedicRegister { get; set; }
        [JsonProperty("med_cpf")]
        public string Cpf { get; set; }
        [JsonProperty("med_end")]
        public string Adress { get; set; }
        [JsonProperty("med_bairro")]
        public string District { get; set; }
        [JsonProperty("med_cidade")]
        public string City { get; set; }
        [JsonProperty("med_uf")]
        public string StateProvince { get; set; }
        [JsonProperty("med_cep")]
        public string PostalCode { get; set; }
        [JsonProperty("med_fone")]
        public string Phone { get; set; }
        [JsonProperty("med_celular")]
        public string MobilePhone { get; set; }
        [JsonProperty("med_fax")]
        public string Fax { get; set; }
        [JsonProperty("med_email")]
        public string Email { get; set; }
        [JsonIgnore]
        public bool Deleted { get; set; }
        [JsonIgnore]
        public DateTime Birthday
        {
            get
            {
                if (string.IsNullOrEmpty(DateOfBirth))
                    return DateTime.Now;

                else
                {
                    DateTime.TryParse(DateOfBirth, out var t);
                    {
                        return t != null ? t : DateTime.Now;

                    };
                }
            }

            set
            {
                if (value.Year > 1900 && value.Year < DateTime.Now.Year)
                    DateOfBirth = value.ToString("yyyy/MM/dd");

                else
                    DateOfBirth = null;
            }
        }
    }
}

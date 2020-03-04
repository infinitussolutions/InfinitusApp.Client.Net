using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    public class BionosticClinic
    {
        public BionosticClinic()
        {
            Medics = new List<BionosticMedic>();
        }

        [JsonProperty("clin_id")]
        public string Id { get; set; }
        [JsonProperty("clin_nome_fantasia")]
        public string FantasyName { get; set; }
        [JsonProperty("clin_razao_social")]
        public string SocialName { get; set; }
        [JsonProperty("clin_cnpj")]
        public string CNPJ { get; set; }
        [JsonProperty("clin_ins_est")]
        public string StateRegistration { get; set; }
        [JsonProperty("clin_ins_mun")]
        public string MunicipalRegistration { get; set; }
        [JsonProperty("clin_end")]
        public string Adress { get; set; }
        [JsonProperty("clin_bairro")]
        public string District { get; set; }
        [JsonProperty("clin_cidade")]
        public string City { get; set; }
        [JsonProperty("clin_uf")]
        public string StateProvince { get; set; }
        [JsonProperty("clin_fone")]
        public string PrimaryPhone { get; set; }
        [JsonProperty("clin_fone2")]
        public string SecundaryPhone { get; set; }
        [JsonProperty("clin_fax")]
        public string Fax { get; set; }
        [JsonProperty("clin_email")]
        public string Email { get; set; }
        [JsonProperty("clin_site")]
        public string Website { get; set; }
        [JsonProperty("clin_cep")]
        public string PostalCode { get; set; }
        [JsonProperty("clin_contato_nome")]
        public string ContactName { get; set; }
        [JsonProperty("clin_contato_cargo")]
        public string ContactPlace { get; set; }
        [JsonProperty("clin_login")]
        public string Login { get; set; }
        [JsonProperty("clin_senha")]
        public string Password { get; set; }
        [JsonProperty("clin_cadastro_confirmado")]
        public DateTimeOffset? ConfirmedRegisterDate { get; set; }
        [JsonProperty("clin_cadastro_analise")]
        public bool RegisterAnalysis { get; set; }
        [JsonProperty("medicos")]
        public IList<BionosticMedic> Medics { get; set; }
    }
}

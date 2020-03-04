using InfinitusApp.Core.Data.Commands.Custom.Bionostic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    /// <summary>
    /// Original Name: "Responsavel"
    /// </summary>
    public class BionosticResponsibleBase
    {
        public BionosticResponsibleBase()
        {
            Contacts = new List<BionosticResponsibleContact>();
        }

        [JsonProperty("resp_id")]
        public string Id { get; set; }
        [JsonProperty("resp_nome")]
        public string Name { get; set; }
        [JsonProperty("resp_cpf")]
        public string CPF { get; set; }
        [JsonProperty("resp_cnpj")]
        public string CNPJ { get; set; }
        [JsonProperty("resp_rg")]
        public string RG { get; set; }
        [JsonProperty("resp_end")]
        public string Adress { get; set; }
        [JsonProperty("resp_bairro")]
        public string District { get; set; }
        [JsonProperty("resp_cidade")]
        public string City { get; set; }
        [JsonProperty("resp_uf")]
        public string StateProvince { get; set; }
        [JsonProperty("resp_cep")]
        public string PostalCode { get; set; }
        [JsonProperty("contatos")]
        public IList<BionosticResponsibleContact> Contacts { get; set; }
        [JsonProperty("resp_senha")]
        public string Password { get; set; }
        [JsonProperty("resp_cadastro_analise")]
        public bool RegisterAnalysis { get; set; }

    }

    public class BionosticResponsibleFull : BionosticResponsibleBase
    {
        public BionosticResponsibleFull()
        {
            Pets = new List<BionosticPetFull>();
        }
        [JsonProperty("pacientes")]
        public IList<BionosticPetFull> Pets { get; set; }
        [JsonIgnore]
        public BionosticPetFull SelectedPet { get; set; }
        public BionosticResponsible GetBionosticResponsible()
        {
            var responsible = new BionosticResponsible()
            {
                Adress = this.Adress,
                City = this.City,
                CNPJ = this.CNPJ,
                Contacts = this.Contacts,
                CPF = this.CPF,
                District = this.District,
                Id = this.Id,
                Name = this.Name,
                Password = this.Password,
                PostalCode = this.PostalCode,
                RegisterAnalysis = this.RegisterAnalysis,
                RG = this.RG,
                StateProvince = this.StateProvince
            };

            responsible.Pets = this.Pets != null ?
                Pets.Select(x => x.GetBionosticPet()).ToList() : 
                new List<BionosticPet>();

            return responsible;
        }
    }

    public class BionosticResponsible : BionosticResponsibleBase
    {
        public BionosticResponsible()
        {
            Pets = new List<BionosticPet>();
        }

        [JsonProperty("pacientes")]
        public IList<BionosticPet> Pets { get; set; }

        
    }

    public class BionosticResponsibleContact
    {
        public BionosticResponsibleContact()
        {
            ContactTypeFromList = BionosticContactTypes.FirstOrDefault();
            Description = string.Empty;
            Observation = string.Empty;
        }

        [JsonProperty("respcont_id")]
        public string Id { get; set; }
        [JsonProperty("respcont_tipo")]
        public string Type { get; set; }
        [JsonProperty("respcont_desc")]
        public string Description { get; set; }
        [JsonProperty("respcont_obs")]
        public string Observation { get; set; }
        [JsonIgnore]
        public string ContactTypeFromList
        {
            get
            {
                return string.IsNullOrEmpty(Type) ? BionosticContactTypes.FirstOrDefault() :
                    BionosticContactTypes.Where(x => x.ToUpper() == Type.ToUpper()).FirstOrDefault();                
            }
            set
            {
                Type = value;
            }
        }
        [JsonIgnore]
        public bool Deleted { get; set; } = false;

        public static readonly List<string> BionosticContactTypes = new List<string>
        {
            "Email",
            "Celular",
            "Residencial",
            "Comercial",
            "Fax",
            "Recado"
        };


        public enum BionosticResponsibleType
        {
            Clinic,
            Tutor
        }
    }
}

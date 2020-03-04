using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    /// <summary>
    /// Original Name: "Paciente"
    /// </summary>
    public class BionosticPetBase
    {
        [JsonProperty("pac_id")]
        public string Id { get; set; }
        [JsonProperty("resp_id")]
        public string ResponsibleId { get; set; }
        [JsonProperty("raca_id")]
        public string RaceId { get; set; }
        [JsonProperty("pac_nome")]
        public string Name { get; set; }
        [JsonProperty("pac_sexo")]
        public string Sex { get; set; }
        [JsonProperty("pac_data_nasc")]
        public string DateOfBirth { get; set; }
        [JsonProperty("pac_pelagem")]
        public string Pelage { get; set; }
        [JsonProperty("pac_registro")]
        public string Registry { get; set; }

        /// <summary>
        /// <para> 0 = Active | 1 = Inactive</para>
        /// <para>Use PetActiveStatus for boolean value</para>
        /// </summary>
        [JsonProperty("pac_desabilitado")]
        public int Inactive { get; set; }
        [JsonIgnore]
        public bool Deleted { get; set; }
        [JsonIgnore]
        public bool Active
        {
            get
            {
                if (Inactive == 0)
                    return true;

                else
                    return false;
            }

            set
            {
                Inactive = value ? 0 : 1;
            }
        }
    }

    public class BionosticPetFull : BionosticPetBase
    {
        [JsonProperty("responsavel")]
        public BionosticResponsibleFull Responsible { get; set; }
        [JsonProperty("esp_nome")]
        public string SpecieName { get; set; }
        [JsonProperty("raca_nome")]
        public string RaceName { get; set; }
        [JsonProperty("raca")]
        public BionosticRaceFull Race { get; set; }
        [JsonIgnore]
        public BionosticSpecie Specie { get; set; }
        
        public BionosticPet GetBionosticPet()
        {
            return new BionosticPet()
            {
                DateOfBirth = this.DateOfBirth,
                Deleted = this.Deleted,
                Id = this.Id,
                Inactive = this.Inactive,
                Name = this.Name,
                Pelage = this.Pelage,
                Race = this.Race,
                RaceId = this.RaceId,
                Registry = this.Registry,
                ResponsibleId = this.ResponsibleId,
                Sex = this.Sex
            };
        }
    }

    public class BionosticPet : BionosticPetBase
    {
        [JsonProperty("raca")]
        public BionosticRace Race { get; set; }
    }
}

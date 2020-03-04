using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    public class BionosticSpecie
    {
        [JsonProperty("esp_id")]
        public string Id { get; set; }
        [JsonProperty("esp_nome")]
        public string Name { get; set; }
    }

    public class BionosticRace
    {
        [JsonProperty("raca_id")]
        public string Id { get; set; }
        [JsonProperty("raca_nome")]
        public string Name { get; set; }
    }

    public class BionosticRaceFull : BionosticRace
    {
        [JsonProperty("especie")]
        public BionosticSpecie Specie { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    public class BionosticCollect
    {
        [JsonProperty("cham_id")]
        public string Id { get; set; }
        [JsonProperty("boy_id")]
        public string MotoboyId { get; set; }
        [JsonProperty("clin_id")]
        public string ClinicId { get; set; }
        [JsonProperty("cham_timestamp")]
        public DateTime? SolicitationDate { get; set; }
        [JsonProperty("cham_hora_saida")]
        public DateTime? SolicitationDateOutForDelivery { get; set; }
        [JsonProperty("cham_hora_chegada")]
        public DateTime? SolicitationDateMotoboyReturn { get; set; }
        [JsonProperty("cham_valor_recebido")]
        public string AmountPaid { get; set; }
        [JsonProperty("cham_solicitante")]
        public string RequesterName { get; set; }
        [JsonProperty("cham_obs")]
        public string Observation { get; set; }
        [JsonProperty("cham_origem")]
        public string Origin { get; set; }
        [JsonProperty("cham_data_agendada")]
        public DateTime? SolicitationScheduledDate { get; set; }
        [JsonProperty("motoboy")]
        public BionosticMotoboy Motoboy { get; set; }
        [JsonProperty("clinica")]
        public BionosticClinic Clinic { get; set; }

    }

    public class BionosticMotoboy
    {
        [JsonProperty("boy_id")]
        public string Id { get; set; }
        [JsonProperty("boy_nome")]
        public string Name { get; set; }
    }

}

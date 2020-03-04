using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    public class BionosticSatisfactionSurvey
    {
        public BionosticSatisfactionSurvey()
        {
            Answers = new Dictionary<string, string>();
        }

        [JsonProperty("clin_id")]
        public string ClinicId { get; set; }
        [JsonProperty("avaliador_nome")]
        public string AppraiserName { get; set; }
        [JsonProperty("avaliador_cargo")]
        public string AppraiserPosition { get; set; }
        [JsonProperty("avaliador_fone")]
        public string AppraiserPhone { get; set; }
        [JsonProperty("avaliador_email")]
        public string AppraiserMail { get; set; }
        [JsonProperty("avaliador_contato_fone")]
        public string AppraiserContactPhone { get; set; }
        [JsonProperty("avaliador_contato_email")]
        public string AppraiserContactMail { get; set; }
        [JsonProperty("respostas")]
        public Dictionary<string, string> Answers { get; set; }
    }

    public class BionosticSatisfactionSurveyQuestion
    {
        [JsonProperty("questao_id")]
        public string Id { get; set; }
        [JsonProperty("questao_txt")]
        public string Description { get; set; }
        [JsonProperty("questao_tipo")]
        public string Type { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Custom.Bionostic
{
    public class BionosticCollectCommand
    {

    }

    public class BionosticCollectCreateCommand : BionosticCollectCommand
    {

        [JsonProperty("cham_solicitante")]
        public string RequesterName { get; set; }
        [JsonProperty("cham_obs")]
        public string Observation { get; set; }
        [JsonProperty("clin_id")]
        public string ClinicId { get; set; }
    }
}

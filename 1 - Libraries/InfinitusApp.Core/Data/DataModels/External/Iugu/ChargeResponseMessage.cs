using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Iugu
{
    public class ChargeResponseMessage
    {
        [JsonProperty("errors")]
        public Dictionary<string, object> Errors { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

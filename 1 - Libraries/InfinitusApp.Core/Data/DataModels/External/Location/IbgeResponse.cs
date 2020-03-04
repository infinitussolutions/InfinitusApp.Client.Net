using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Location
{
    public class IbgeResponse
    {

    }

    public class IbgeStateProvince
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("sigla")]
        public string Initials { get; set; }
    }
}

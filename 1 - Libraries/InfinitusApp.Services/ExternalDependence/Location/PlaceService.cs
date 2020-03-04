using InfinitusApp.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Location
{
    public class PlaceService
    {
        static string _googleMapsKey = "AIzaSyC6ViThoTIxSxxcmd-wfMfr00aqHDUBUaI";

        private const string ApiBaseAddress = "https://maps.googleapis.com/maps/";

        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public async Task<GooglePlaceAutoCompleteResult> GetPlaces(string text)
        {
            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync($"api/place/autocomplete/json?input={Uri.EscapeUriString(text)}&language=pt_BR&key={_googleMapsKey}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json) && json != "ERROR")
                    {
                        return await Task.Run(() => JsonConvert.DeserializeObject<GooglePlaceAutoCompleteResult>(json)).ConfigureAwait(false);
                    }
                }
            }

            return new GooglePlaceAutoCompleteResult();
        }

        public async Task<GooglePlaceDetail> GetPlaceDetails(string placeId)
        {
            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync($"api/place/details/json?placeid={Uri.EscapeUriString(placeId)}&key={_googleMapsKey}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json) && json != "ERROR")
                    {
                        return await Task.Run(() => JsonConvert.DeserializeObject<GooglePlaceDetail>(json)).ConfigureAwait(false);
                    }
                }
            }

            return new GooglePlaceDetail();
        }
    }

    public class GooglePlaceAutoCompletePrediction
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("structured_formatting")]
        public StructuredFormatting StructuredFormatting { get; set; }

    }

    public class StructuredFormatting
    {
        [JsonProperty("main_text")]
        public string MainText { get; set; }

        [JsonProperty("secondary_text")]
        public string SecondaryText { get; set; }
    }

    public class GooglePlaceAutoCompleteResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("predictions")]
        public List<GooglePlaceAutoCompletePrediction> AutoCompletePlaces { get; set; }
    }
}

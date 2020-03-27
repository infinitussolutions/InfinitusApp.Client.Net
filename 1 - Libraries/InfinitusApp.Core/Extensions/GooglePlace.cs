using InfinitusApp.Core.Data.DataModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Extensions
{

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public List<string> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string adr_address { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public List<string> types { get; set; }
        public string url { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
    }

    public class GooglePlaceDetail
    {
        public List<object> html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
    }

    public static class GooglePlaceExtend
    {
        public static Address ToAddress(this GooglePlaceDetail googlePlaceDetail)
        {
            var a = new Address
            {
                CreatedAt = DateTime.Now,
                AddressLine1 = googlePlaceDetail?.result?.address_components?.Where(x => x.types.Any(y => y.Equals("route")))?.FirstOrDefault()?.short_name,
                City = googlePlaceDetail?.result?.address_components?.Where(x => x.types.Any(y => y.Equals("administrative_area_level_2")))?.FirstOrDefault()?.short_name,
                District = googlePlaceDetail?.result?.address_components?.Where(x => x.types.Any(y => y.Equals("sublocality_level_1")))?.FirstOrDefault()?.short_name,
                Country = googlePlaceDetail?.result?.address_components?.Where(x => x.types.Any(y => y.Equals("country")))?.FirstOrDefault()?.long_name,
                CountyCode = googlePlaceDetail?.result?.address_components?.Where(x => x.types.Any(y => y.Equals("country")))?.FirstOrDefault()?.short_name,
                StateProvince = googlePlaceDetail?.result?.address_components?.Where(x => x.types.Any(y => y.Equals("administrative_area_level_1")))?.FirstOrDefault()?.short_name,
                PostalCode = googlePlaceDetail?.result?.address_components?.Where(x => x.types.Any(y => y.Equals("postal_code")))?.FirstOrDefault()?.short_name?.Replace("-", ""),
                //Number = googlePlaceDetail?.result?.address_components?.Where(x => x.types.Any(y => y.Equals("street_number")))?.FirstOrDefault()?.short_name,
                Location = new Data.DataModels.Location
                {
                    Latitude = googlePlaceDetail.result.geometry.location.lat,
                    Longitude = googlePlaceDetail.result.geometry.location.lng
                }
            };

            return a;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using InfinitusApp.Core.Data.DataModels;

namespace InfinitusApp.Services.ExternalDependence.Feed
{
    public class RssService
    {
        public RssService()
        {

        }

        public async Task<List<InfinitusApp.Core.Data.DataModels.Publication>> GetInfos()
        {
            Uri geturi = new Uri("http://fabricaapp.com/feed/"); //replace your xml url  
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);
            string response = await responseGet.Content.ReadAsStringAsync();//Getting response

            var image = XDocument.Parse(response).Descendants("image")
                .Select(x => new
                {
                    Url = (string)x.Element("url"),
                    Title = (string)x.Element("title"),
                    Link = (string)x.Element("link")
                }).ToList();


            var items = XDocument.Parse(response)
                .Descendants("item")
                .Select(i => new
                {
                    Title = (string)i.Element("title"),
                    Description = (string)i.Element("description"),
                    Link = (string)i.Element("link"),
                    CreatAt = (DateTime)i.Element("pubDate"),
                    Encoded = @"<html><body> " + (string)i.Element("{http://purl.org/rss/1.0/modules/content/}encoded") + "</body></html> ", //<-- ***

                })
                .ToList();

            var publications = items.Select(x => new InfinitusApp.Core.Data.DataModels.Publication
            {
                CreatedAt = x.CreatAt,
                HtmlUri = x.Link,
                CreatedBy = new ApplicationUser
                {
                    FirstName = image?.FirstOrDefault()?.Title,
                    FullName = image?.FirstOrDefault()?.Title
                },
                MediaImageData = new MediaImageData
                {
                    WideImageUri = image?.FirstOrDefault()?.Url
                },
                Description = new DataItemDescriptionInfo
                {
                    Title = x?.Title,
                    SubTitle = x?.Description,
                    Body = x?.Encoded
                },
                ShowOnFeed = true,
                FeedType = FeedType.Feed
            }).ToList();

            return publications;
        }
    }
}

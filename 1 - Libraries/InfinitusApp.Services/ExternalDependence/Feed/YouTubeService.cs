using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Feed
{
    public class YouTubeService
    {
        public string ChannelId { get; set; }

        public string ApiKey { get; set; }

        public string ChannelName { get; set; }

        public YouTubeService()
        {
            // Get your API Key @ https://console.developers.google.com/apis/api/youtube/
            // Documentation @ https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.videos.list 
            // Parameters https://developers.google.com/youtube/v3/docs/videos/list

            ApiKey = "AIzaSyC6ViThoTIxSxxcmd-wfMfr00aqHDUBUaI";
            ChannelId = "UCZ1bVhVLHjnLkCRx2IiiBPA";
            ChannelName = "Infinitus Solutions";
        }

        public async Task<List<InfinitusApp.Core.Data.DataModels.Publication>> GetInfo()
        {
            string channelUrl = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=20&order=date&channelId=" + ChannelId + "&key=" + ApiKey + "";

            using (var httpClient = new HttpClient())
            {
                var videoIds = new List<string>();
                var json = await httpClient.GetStringAsync(channelUrl);

                // Deserialize our data, this is in a simple List format
                var response = JsonConvert.DeserializeObject<YouTubeApiListRoot>(json);

                // Add all the video id's we've found to our list.
                videoIds.AddRange(response.items.Select(item => item.id.videoId));

                // Get the details for all our items
                var itens = await GetVideoDetailsAsync(videoIds);

                return itens.Select(x => new InfinitusApp.Core.Data.DataModels.Publication
                {
                    CreatedAt = x.PublishedAt,
                    HtmlUri = "https://www.youtube.com/embed/" + x.VideoId + "?autoplay=1&controls=1&modestbranding&rel=0",
                    CreatedBy = new Core.Data.DataModels.ApplicationUser
                    {
                        FirstName = ChannelName,
                        FullName = ChannelName
                    },
                    MediaImageData = new Core.Data.DataModels.MediaImageData
                    {
                        WideImageUri = x.HighThumbnailUrl
                    },
                    Description = new Core.Data.DataModels.DataItemDescriptionInfo
                    {
                        Title = x.Title,
                        Body = x.Description
                    },
                    ShowOnFeed = true,
                    FeedType = Core.Data.DataModels.FeedType.YouTube
                }).ToList();
            }
        }

        async Task<List<YouTubeItem>> GetVideoDetailsAsync(List<string> videoIds)
        {
            string detailsUrl = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&key=" + ApiKey + "&id={0}";

            var videoIdString = string.Join(",", videoIds);
            var youtubeItems = new List<YouTubeItem>();

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Format(detailsUrl, videoIdString));
                var response = JsonConvert.DeserializeObject<YouTubeApiDetailsRoot>(json);

                foreach (var item in response.items)
                {
                    var youTubeItem = new YouTubeItem()
                    {
                        Title = item.snippet.title,
                        Description = item.snippet.description,
                        ChannelTitle = item.snippet.channelTitle,
                        PublishedAt = item.snippet.publishedAt,
                        VideoId = item.id,
                        DefaultThumbnailUrl = item.snippet?.thumbnails?.@default?.url,
                        MediumThumbnailUrl = item.snippet?.thumbnails?.medium?.url,
                        HighThumbnailUrl = item.snippet?.thumbnails?.high?.url,
                        StandardThumbnailUrl = item.snippet?.thumbnails?.standard?.url,
                        MaxResThumbnailUrl = item.snippet?.thumbnails?.maxres?.url,
                        ViewCount = item.statistics?.viewCount,
                        LikeCount = item.statistics?.likeCount,
                        DislikeCount = item.statistics?.dislikeCount,
                        FavoriteCount = item.statistics?.favoriteCount,
                        CommentCount = item.statistics?.commentCount,
                        Tags = item.snippet?.tags
                    };

                    youtubeItems.Add(youTubeItem);
                }
            }

            return youtubeItems;
        }
    }

    public class YouTubeItem
    {
        public string VideoId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DescriptionShort
        {
            get
            {
                if (Description.Length <= 150)
                    return Description;

                return Description.Substring(0, 150) + "...";
            }
        }

        public string ChannelTitle { get; set; }

        public string DefaultThumbnailUrl { get; set; }

        public string MediumThumbnailUrl { get; set; }

        public string HighThumbnailUrl { get; set; }

        public string StandardThumbnailUrl { get; set; }

        public string MaxResThumbnailUrl { get; set; }

        public DateTime PublishedAt { get; set; }

        //public string PublishedAtHumanized { get { return PublishedAt.Humanize(); } }

        public int? ViewCount { get; set; }

        public int? LikeCount { get; set; }

        public int? DislikeCount { get; set; }

        public int? FavoriteCount { get; set; }

        public int? CommentCount { get; set; }

        public List<string> Tags { get; set; }
    }

    public class YouTubeApiListId
    {
        public string kind { get; set; }
        public string videoId { get; set; }
    }

    public class YouTubeApiListItem
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public YouTubeApiListId id { get; set; }
    }

    public class YouTubeApiListRoot
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string nextPageToken { get; set; }
        public string regionCode { get; set; }
        public List<YouTubeApiListItem> items { get; set; }
    }

    public class Default
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class High
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Standard
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Maxres
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnails
    {
        public Default @default { get; set; }
        public Medium medium { get; set; }
        public High high { get; set; }
        public Standard standard { get; set; }
        public Maxres maxres { get; set; }
    }

    public class Localized
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Snippet
    {
        public DateTime publishedAt { get; set; }
        public string channelId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumbnails thumbnails { get; set; }
        public string channelTitle { get; set; }
        public List<string> tags { get; set; }
        public string categoryId { get; set; }
        public string liveBroadcastContent { get; set; }
        public string defaultLanguage { get; set; }
        public Localized localized { get; set; }
        public string defaultAudioLanguage { get; set; }
    }

    public class Statistics
    {
        public int? viewCount { get; set; }
        public int? likeCount { get; set; }
        public int? dislikeCount { get; set; }
        public int? favoriteCount { get; set; }
        public int? commentCount { get; set; }
    }

    public class YouTubeApiDetailsItem
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public Snippet snippet { get; set; }
        public Statistics statistics { get; set; }
    }

    public class YouTubeApiDetailsRoot
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public List<YouTubeApiDetailsItem> items { get; set; }
    }
}

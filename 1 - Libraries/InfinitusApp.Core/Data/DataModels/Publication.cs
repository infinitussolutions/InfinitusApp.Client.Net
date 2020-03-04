using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Publication : Naylah.Core.Entities.EntityBase
    {
        public Publication()
        {
            TargetUserGroups = new List<ApplicationUserGroup>();
            MediaImageData = new MediaImageData();
            Description = new DataItemDescriptionInfo();
            DataItem = new DataItem();
        }

        public bool ShowOnFeed { get; set; }

        public string HtmlUri { get; set; }

        public PublicationTargetType TargetType { get; set; }

        public DataItemDescriptionInfo Description { get; set; }

        public MediaImageData MediaImageData { get; set; }

        public DataItem DataItem { get; set; }

        public string DataItemId { get; set; }

        public string DataStoreId { get; set; }

        public IList<ApplicationUserGroup> TargetUserGroups { get; set; }

        public ApplicationUser CreatedBy { get; set; }

        public int Position { get; set; }

        [JsonIgnore]
        public FeedType FeedType { get; set; } = FeedType.Infinitus;

        [JsonIgnore]
        public string CreatedByPresentation
        {
            get
            {
                var msgReturn = "";

                if (string.IsNullOrEmpty(CreatedBy?.FirstName))
                    return msgReturn;

                msgReturn = "Por: " + CreatedBy?.FullName;

                return msgReturn;
            }
        }

        //[JsonIgnore]
        //public double Distance { get; set; }

        [JsonIgnore]
        public string DistancePresentation
        {
            get
            {
                return DataItem.DistanceFromActualLocation.Presentation;

                //var msgReturn = "";

                //if (Distance == 0)
                //    msgReturn += "Próximo";

                //else
                //{
                //    if (Distance > 1000)
                //        msgReturn += Distance + " Km"; //Convert.ToString(Math.Round(Distance * 1000, 0)) + " Mtrs";

                //    else
                //        msgReturn += Distance + " Mts"; //msgReturn += Convert.ToString(Math.Round(Distance, 0)) + " Km";


                //    //if (Distance < 1)
                //    //    msgReturn += Convert.ToString(Math.Round(Distance * 1000, 0)) + " Mtrs";

                //    //else
                //    //    msgReturn += Convert.ToString(Math.Round(Distance, 0)) + " Km";
                //}

                //return msgReturn;
            }
        }

        [JsonIgnore]
        public string DeliveryInfo { get; set; }

        [JsonIgnore]
        public string FirstAddressPresentation
        {
            get
            {
                if (string.IsNullOrEmpty(DataItem?.FirstAddressPresentation))
                    return "";

                return DataItem.FirstAddressPresentation;
            }
        }

        [JsonIgnore]
        public string OperatingPresentation
        {
            get
            {
                if (string.IsNullOrEmpty(DataItem?.OperatingPresentation) || !DataItem.HasOperating)
                    return "";

                return DataItem.OperatingPresentation;
            }
        }

        [JsonIgnore]
        public string OperatingNowPresentation
        {
            get
            {
                if (string.IsNullOrEmpty(OperatingPresentation))
                    return "";

                var a = OperatingPresentation.Split(',');

                return a.FirstOrDefault();
            }
        }

        [JsonIgnore]
        public string OperatingTimePresentation
        {
            get
            {
                if (string.IsNullOrEmpty(OperatingPresentation))
                    return "";

                var a = OperatingPresentation.Split(',');

                return a.LastOrDefault();
            }
        }

        [JsonIgnore]
        public bool IsAdmin { get; set; }

        [JsonIgnore]
        public bool ShowMessageBlockIfNotOperating { get; set; }

        [JsonIgnore]
        public bool IsPublication
        {
            get
            {
                return string.IsNullOrEmpty(DataItemId);
            }
        }

        [JsonIgnore]
        public bool NotIsPublication
        {
            get
            {
                return !IsPublication;
            }
        }

        [JsonIgnore]
        public bool IsInfinitusType
        {
            get
            {
                return FeedType == FeedType.Infinitus;
            }
        }

        [JsonIgnore]
        public bool NotIsInfinitusType
        {
            get
            {
                return !IsInfinitusType;
            }
        }

        [JsonIgnore]
        public bool IsFeedType
        {
            get
            {
                return FeedType == FeedType.Feed;
            }
        }

        [JsonIgnore]
        public bool NotIsFeedType
        {
            get
            {
                return !IsFeedType;
            }
        }

        [JsonIgnore]
        public bool IsYouTubeType
        {
            get
            {
                return FeedType == FeedType.YouTube;
            }
        }

        [JsonIgnore]
        public string CreatedAtPresentation
        {
            get
            {
                if (!CreatedAt.HasValue)
                    return "";

                return CreatedAt.Value.ToString("dd/MM/yy") + " (" + CreatedAt.Value.DayOfWeek.ToPresentation() + ")";
            }
        }
    }

    public enum PublicationTargetType
    {
        None,
        AllUsers,
        UserGroups
    }

    public enum FeedType
    {
        Infinitus,
        Feed,
        YouTube
    }
}
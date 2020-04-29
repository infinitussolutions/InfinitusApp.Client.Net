using InfinitusApp.Core.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ApplicationBase : Naylah.Core.Entities.EntityBase
    {
        public string InfinitusAppSubscriptionSolution { get; set; }

        public string AppId { get; set; }

        public string AppSecret { get; set; }

        public string Name { get; set; }

        public string DataStoreId { get; set; }

        public bool VisibleInFabricaApp { get; set; }

        #region Helper

        public bool IsPluzapService
        {
            get
            {
                return AppId.Equals("89deeb5a-b41a-4091-96fb-d71744cf100c");
            }
        }

        public bool IsPluzapFood
        {
            get
            {
                return AppId.Equals("9ab018a0-d236-426e-b067-88b849710d32");
            }
        }

        public bool IsPluzapStore
        {
            get
            {
                return AppId.Equals("afd6269d-5243-4a41-9e3e-3f52b7880724");
            }
        }

        public bool IsPluzapDelivery
        {
            get
            {
                return AppId.Equals("36dcf919-5bec-4582-bfe3-1c7596d6362a");
            }
        }

        public bool IsPluzap
        {
            get
            {
                return IsPluzapFood || IsPluzapService || IsPluzapStore || IsPluzapDelivery || Name.ToUpper().Contains("PLUZAPP");
            }
        }

        #endregion
    }

    public class Application : ApplicationBase
    {
        public Application()
        {
            Logo = new MediaImageData();
            Style = new ApplicationStyle();
            CompanyInformation = new CompanyInformation();
            Users = new List<ApplicationUserBase>();
            Indications = new List<Indication>();
            Notifications = new List<ApplicationNotification>();
            Settings = new ApplicationSettings();
            NaylahIdentityClient = new ApplicationNaylahIdentityClient();
            PublicationStoreInfo = new PublicationStoreInfo();
            Customization = new ApplicationCustomization();
            Structures = new List<StructureConfiguration>();
        }

        public ApplicationSettings Settings { get; set; }

        public MediaImageData Logo { get; set; }

        public ApplicationStyle Style { get; set; }

        public CompanyInformation CompanyInformation { get; set; }

        public DataStore DataStore { get; set; }

        public ApplicationNaylahIdentityClient NaylahIdentityClient { get; set; }

        public IList<ApplicationUserBase> Users { get; set; }

        public IList<ApplicationNotification> Notifications { get; set; }

        public IList<Indication> Indications { get; set; }

        public IList<StructureConfiguration> Structures { get; set; }

        public PublicationStoreInfo PublicationStoreInfo { get; set; }

        public ApplicationCustomization Customization { get; set; }

        public TermsOfUse TermsOfUse { get; set; }

        #region Helps

        [JsonIgnore]
        public bool UseGeolocation
        {
            get
            {
                if (Structures == null)
                    return false;

                return Structures.Any(x => x.Target.TargetInfo.OrderType == PageOrderType.Distance);
            }
        }

        #endregion
    }

    public class ApplicationStyle
    {
        public ApplicationStyle()
        {
            ColorScheme = new MaterialDesign.ColorScheme();
            Font = new FontInfo();
        }

        public MaterialDesign.ColorScheme ColorScheme { get; set; }

        public FontInfo Font { get; set; }
        ////[Obsolete("Use material design color scheme")]
        //public string Color1 { get; set; }

        ////[Obsolete("Use material design color scheme")]
        //public string Color2 { get; set; }

        ////[Obsolete("Use material design color scheme")]
        //public string Color3 { get; set; }

        ////[Obsolete("Use material design color scheme")]
        //public string Color4 { get; set; }

        ////[Obsolete("Use material design color scheme")]
        //public string Color5 { get; set; }
    }

    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
        }

        public string AzureNotificationHubName { get; set; }

        public string AzureNotificationHubConnectionString { get; set; }
    }

    public class ApplicationCustomization
    {
        public ApplicationCustomization()
        {
            NotificationCustomization = new ApplicationNotificationCustomization();
            AppUserCustomization = new ApplicationAppUserCustomization();
            Timeline = new ApplicationTimelineCustomization();
        }
        [Obsolete]
        public bool UseGeolocation { get; set; }

        public bool ShowMessageClosedAndBlockDataItemWithSchedule { get; set; }

        public ApplicationNotificationCustomization NotificationCustomization { get; set; }

        public ApplicationAppUserCustomization AppUserCustomization { get; set; }

        public ApplicationTimelineCustomization Timeline { get; set; }

        [JsonIgnore]
        public bool NotUseGeolocation { get { return !UseGeolocation; } }
    }

    public class ApplicationNotificationCustomization
    {
        public ApplicationNotificationCustomization()
        {
            GroupsIdsToNotify = new List<string>();
        }

        public bool NotifyNewDataItemsPaid { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// In Km
        /// </summary>
        public int MaxDistance { get; set; }
        public List<string> GroupsIdsToNotify { get; set; }
        public string CustomTag { get; set; }

        [JsonIgnore]
        public bool NotifyUsingLocation
        {
            get
            {
                return MaxDistance > 0;
            }
        }
    }

    public class ApplicationAppUserCustomization
    {
        public ApplicationAppUserCustomization()
        {

        }

        public bool NeedUser { get; set; }
        public bool NeedUserGroup { get; set; }
        public bool AllowMultipleGroups { get; set; }
    }

    public class ApplicationTimelineCustomization
    {
        public ApplicationTimelineCustomization()
        {

        }

        public TimelineType Type { get; set; }

        public enum TimelineType
        {
            Horizontal,
            Vertical
        }
    }

    public class ApplicationNaylahIdentityClient
    {
        public ApplicationNaylahIdentityClient()
        {
            Logo = new MediaImageData();
            Style = new ApplicationNaylahIdentityClientStyle();
        }

        public string Id { get; set; }

        public bool Enabled { get; set; }

        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientUri { get; set; }

        public MediaImageData Logo { get; set; }

        public ApplicationNaylahIdentityClientStyle Style { get; set; }

        public class ApplicationNaylahIdentityClientStyle
        {
            public ApplicationNaylahIdentityClientStyle()
            {
                ColorScheme = new MaterialDesign.ColorScheme();
            }

            public MaterialDesign.ColorScheme ColorScheme { get; set; }

            public string Color1 { get; set; }

            public string Color2 { get; set; }

            public string Color3 { get; set; }

            public string Color4 { get; set; }

            public string Color5 { get; set; }
        }

    }
}
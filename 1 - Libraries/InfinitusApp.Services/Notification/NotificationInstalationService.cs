using InfinitusApp.Core.Extensions;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Notification
{
    public class NotificationInstalationService : ServiceBase
    {
        public NotificationInstalationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task Register(string pushChannel, string platform, IList<string> customTags = null)
        {
            var notificationInstallation = new NotificationInstallation()
            {
                Platform = platform,
                PushChannel = pushChannel,
                Tags = customTags
            };

            var dic = new Dictionary<string, string>();
            dic.Add("installationId", ServiceClient.MobileServiceClient.InstallationId);
            await ServiceClient.InvokeApiAsync("NotificationInstallations/CreateOrUpdateInstallation", JToken.FromObject(notificationInstallation), HttpMethod.Put, dic);
        }

        public async Task Unregister()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("installationId", ServiceClient.MobileServiceClient.InstallationId);
            await ServiceClient.InvokeApiAsync("NotificationInstallations/DeleteInstallation", HttpMethod.Delete, dic);
        }
    }

    public class NotificationInstallation
    {
        public NotificationInstallation()
        {
        }

        //The device installation id to register.
        public string InstallationId { get; set; }

        //Wns stands for "Windows Push Notification Services", and apns is "Apple Push Notification Service".
        //[Required]
        public string Platform { get; set; }

        // The channel URI if registering the installation for WNS; Device Token if registering for APNS.
        //[Required]
        public string PushChannel { get; set; }

        //A dictionary of secondary tile names to Microsoft.Azure.Mobile.Server.Notifications.NotificationSecondaryTile
        //objects to register with this installation.
        //[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Set is used in Test.")]
        //public IDictionary<string, NotificationSecondaryTile> SecondaryTiles { get; set; }

        //A list of tags to register with this installation.
        //[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Set is used in Test.")]
        public IList<string> Tags { get; set; }

        //
        // Summary:
        //     A dictionary of template names to Microsoft.Azure.Mobile.Server.Notifications.NotificationTemplate
        //     objects.
        //[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Set is used in Test.")]
        //public IDictionary<string, NotificationTemplate> Templates { get; set; }
    }
}
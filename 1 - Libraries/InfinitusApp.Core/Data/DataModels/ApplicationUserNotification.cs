using System;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ApplicationUserNotification : Naylah.Core.Entities.EntityBase
    {
        public ApplicationUserNotification()
        {
            ReadData = new ApplicationUserNotificationReadInfo();
            SentData = new ApplicationUserNotificationSentInfo();
        }

        public ApplicationUserNotificationReadInfo ReadData { get; set; }

        public ApplicationUserNotificationSentInfo SentData { get; set; }

        public string UserId { get; set; }

        public string NotificationId { get; set; }

        public ApplicationUser User { get; set; }

        public ApplicationNotification Notification { get; set; }
    }

    public class ApplicationUserNotificationReadInfo
    {
        public bool Read { get; set; }

        public DateTime? ReadDate { get; set; }
    }

    public class ApplicationUserNotificationSentInfo
    {
        public bool Sent { get; set; }

        public DateTime? SentDate { get; set; }
    }
}
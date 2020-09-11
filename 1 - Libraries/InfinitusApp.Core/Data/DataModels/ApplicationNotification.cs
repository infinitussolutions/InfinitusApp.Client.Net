using Newtonsoft.Json;

namespace InfinitusApp.Core.Data.DataModels
{
    public enum ApplicationNotificationType
    {
        Default,
        Agenda,
        Publication,
        FinancialRequest
    }

    public class ApplicationNotification : Naylah.Core.Entities.EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ApplicationId { get; set; }

        public string ParameterId { get; set; }

        public ApplicationNotificationType? Type { get; set; }
    }

    public class NotificationBalance
    {
        public int MonthlyBalance { get; set; }
        public int ExtraBalance { get; set; }

        [JsonIgnore]
        public int TotalBalance
        {
            get
            {
                return MonthlyBalance + ExtraBalance;
            }
        }
    }
}
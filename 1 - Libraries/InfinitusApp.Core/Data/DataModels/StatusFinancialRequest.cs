using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class StatusFinancialRequest : EntityBase
    {
        public StatusFinancialRequest()
        {
            Action = new StatusActionsFinancialRequest();
            Config = new StatusFinancialRequestConfig();
        }

        public string Title { get; set; }

        public StatusActionsFinancialRequest Action { get; set; }

        public StatusFinancialRequestConfig Config { get; set; }

        #region Relations

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        public virtual IList<FinancialRequestStatusRelation> FinancialRequestStatusRelations { get; set; }

        #endregion

    }

    public class StatusActionsFinancialRequest
    {
        public StatusActionsFinancialRequest()
        {
            Notification = new NotifyActionStatusFinancialRequest();
            User = new UserStatusFinancialRequest();
        }

        public NotifyActionStatusFinancialRequest Notification { get; set; }

        public UserStatusFinancialRequest User { get; set; }
    }

    public class NotifyActionStatusFinancialRequest
    {
        public bool SendWhatsapp { get; set; }
        public bool SendEmail { get; set; }
        public bool SendPushNotification { get; set; }
    }

    public class UserStatusFinancialRequest
    {
        public bool EditRequest { get; set; }
        public bool CancelRequest { get; set; }
    }

    public class StatusFinancialRequestConfig
    {
        public StatusFinancialRequestConfig()
        {
            Delivery = new StatusFinancialRequestDeliveryConfig();
        }

        public bool IsClosed { get; set; }

        public StatusFinancialRequestDeliveryConfig Delivery { get; set; }
    }

    public class StatusFinancialRequestDeliveryConfig
    {
        public bool Available { get; set; }

        public bool On { get; set; }
    }

    public static class StatusFinancialRequestExtention
    {
        public static StatusFinancialRequest GetPossibleNextStatus(this FinancialRequest financialRequest, List<StatusFinancialRequest> statusList)
        {
            var currentStatus = financialRequest.CurrentStatus;

            if (currentStatus.Config.IsClosed)
                return null;

            var closedStatus = statusList.FirstOrDefault(x => x.Deleted == false && x.Id != currentStatus.Id && x.Config.IsClosed == true);

            var availableToDeliveryStatus = statusList.FirstOrDefault(x => x.Deleted == false && x.Id != currentStatus.Id && x.Config.Delivery.Available == true);

            var onDeliverytatus = statusList.FirstOrDefault(x => x.Deleted == false && x.Id != currentStatus.Id && x.Config.Delivery.On == true);

            switch (financialRequest.DeliveryInfo.Type)
            {
                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.InHands:
                    return currentStatus.Config.Delivery.Available ? closedStatus : availableToDeliveryStatus;


                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.Humanized:
                    return currentStatus.Config.Delivery.Available ? onDeliverytatus : currentStatus.Config.Delivery.On ? closedStatus : availableToDeliveryStatus;

                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.Normal:
                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.Unknown:
                default:
                    return closedStatus;
            }
        }
    }
}

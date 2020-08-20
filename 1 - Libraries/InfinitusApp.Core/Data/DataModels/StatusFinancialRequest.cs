﻿using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
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
        public bool IsClosed { get; set; }

        public StatusFinancialRequestDeliveryConfig Delivery { get; set; }
    }

    public class StatusFinancialRequestDeliveryConfig
    {
        public bool Available { get; set; }

        public bool On { get; set; }
    }
}

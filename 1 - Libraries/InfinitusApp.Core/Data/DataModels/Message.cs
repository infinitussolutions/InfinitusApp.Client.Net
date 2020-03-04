using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Message : Naylah.Core.Entities.EntityBase
    {
        public string Subject { get; set; }

        public string Text { get; set; }

        public MessageType MessageType { get; set; }

        #region Relations

        public virtual string DataStoreId { get; set; }

        #endregion
    }

    public enum MessageType
    {
        Email,
        SMS,
        WhatsApp
    }

    public enum MessageLinkFields
    {
        AppUserFirstName,
        AppUserFullName,
        AppUserEmail,
        AppName,
        AppAndroidLink,
        AppIOSLink
    }
}

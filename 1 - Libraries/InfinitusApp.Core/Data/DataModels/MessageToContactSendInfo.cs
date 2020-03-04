using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class MessageToContactSendInfo : Naylah.Core.Entities.EntityBase
    {
        public MessageToContactSendInfo()
        {
            Message = new Message();
            MessageContact = new MessageContact();
        }

        public virtual Message Message { get; set; }

        public virtual string MessageId { get; set; }

        public virtual MessageContact MessageContact { get; set; }

        public virtual string MessageContactId { get; set; }

        public virtual string DataStoreId { get; set; }
    }
}

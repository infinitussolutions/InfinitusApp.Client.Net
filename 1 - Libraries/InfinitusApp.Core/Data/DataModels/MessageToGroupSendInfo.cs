using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class MessageToGroupSendInfo : Naylah.Core.Entities.EntityBase
    {
        public MessageToGroupSendInfo()
        {
            Message = new Message();
            MessageContactGroup = new MessageContactGroup();
        }

        public virtual Message Message { get; set; }

        public virtual string MessageId { get; set; }

        public virtual MessageContactGroup MessageContactGroup { get; set; }

        public virtual string MessageContactGroupId { get; set; }

        public virtual string DataStoreId { get; set; }
    }
}

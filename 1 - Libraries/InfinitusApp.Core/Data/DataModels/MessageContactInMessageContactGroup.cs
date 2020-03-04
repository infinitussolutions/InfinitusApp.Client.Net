using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class MessageContactInMessageContactGroup : Naylah.Core.Entities.EntityBase
    {
        public MessageContactInMessageContactGroup()
        {
            MessageContact = new MessageContact();
            MessageContactGroup = new MessageContactGroup();
        }

        public virtual MessageContact MessageContact { get; set; }

        public virtual string MessageContactId { get; set; }

        public virtual MessageContactGroup MessageContactGroup { get; set; }

        public virtual string MessageContactGroupId { get; set; }

        #region Relations

        public virtual string DataStoreId { get; set; }

        #endregion
    }
}

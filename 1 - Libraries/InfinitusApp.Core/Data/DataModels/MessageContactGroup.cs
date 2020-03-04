using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class MessageContactGroup : Naylah.Core.Entities.EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        #region Relations

        public virtual string DataStoreId { get; set; }

        #endregion
    }
}

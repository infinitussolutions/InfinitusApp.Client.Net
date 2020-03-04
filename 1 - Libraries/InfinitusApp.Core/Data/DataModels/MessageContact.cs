using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class MessageContact : Naylah.Core.Entities.EntityBase
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Company { get; set; }

        #region Relations

        public virtual string DataStoreId { get; set; }

        #endregion
    }
}

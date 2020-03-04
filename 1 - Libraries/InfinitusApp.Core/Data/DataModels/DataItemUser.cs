using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class DataItemUser : Naylah.Core.Entities.EntityBase
    {
        public DataItemUser()
        {

        }

        public DataItemUserType RelationType { get; set; }

        #region Relations

        public DataItem DataItem { get; set; }
        public string DataItemId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        #endregion

        public enum DataItemUserType
        {
            Unknown,
            Inscription,
            AllowRating,
            Favorite
        }
    }
}

using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ApplicationUserInteractionRating : EntityBase
    {
        public string Comment { get; set; }

        /// <summary>
        /// Stars or anything that defines the rating
        /// </summary>
        public double Value { get; set; }

        #region Relations

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual string ApplicationUserId { get; set; }

        public virtual DataItem DataItem { get; set; }

        public virtual string DataItemId { get; set; }

        public virtual string DataStoreId { get; set; }

        #endregion

        #region Helper

        public string CreateAtPresentation
        {
            get
            {
                if (CreatedAt == null)
                    return "";

                return UpdatedAt != null ?
                    UpdatedAt.Value.ToString("dd 'de' MMMMM 'de' yyyy") :
                    CreatedAt.Value.ToString("dd 'de' MMMMM 'de' yyyy");
            }
        }

        #endregion
    }

    public class DataItemRatingPresentation
    {
        public DataItemRatingPresentation()
        {
            DataItem = new DataItem();
        }

        public double Rating { get; set; }

        public int Count { get; set; }

        public virtual DataItem DataItem { get; set; }

        public string MessageCount
        {
            get
            {
                if (Count == 0)
                    return "";

                return "Média entre " + Count + " opniões";
            }
        }

        public string MessageSimpleRating
        {
            get
            {
                if (Count == 0)
                    return "";

                var ratting = Count > 10 ? "10+" : Count > 50 ? "50+" : Count > 100 ? "100+" : Count > 200 ? "200+" : Count > 300 ? "300+" : Count > 400 ? "400+" : Count > 500 ? "500+" : Count > 999 ? "999+" : Count.ToString();

                return Rating + " (" + ratting + ")";
            }
        }
    }
}

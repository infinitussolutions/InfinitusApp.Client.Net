using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class DeliveryFee : Naylah.Core.Entities.EntityBase
    {
        public DeliveryFee()
        {
            Price = new Price();
            DataItem = new DataItem();
        }

        public double Kilometer { get; set; }

        public Price Price { get; set; }

        #region Relations

        public DataItem DataItem { get; set; }

        public string DataItemId { get; set; }

        public string DataStoreId { get; set; }

        #endregion

        #region Helpers

        public bool IsLast { get; set; }

        #endregion
    }
}

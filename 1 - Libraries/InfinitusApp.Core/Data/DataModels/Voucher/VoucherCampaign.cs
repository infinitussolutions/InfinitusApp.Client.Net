using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Voucher
{
    public class VoucherCampaign : Naylah.Core.Entities.EntityBase
    {
        public VoucherCampaign()
        {
            VoucherGeneratedList = new List<VoucherGenerate>();
            Config = new VoucherCampaignConfig();
        }

        public string Title { get; set; }

        public VoucherCampaignConfig Config { get; set; }

        #region Relations

        public IList<VoucherGenerate> VoucherGeneratedList { get; set; }

        /// <summary>
        /// Set it if campaign is to dataitem company or department
        /// </summary>
        public DataItem ParentDataItem { get; set; }

        public string ParentDataItemId { get; set; }

        public string DataStoreId { get; set; }

        #endregion
    }
}

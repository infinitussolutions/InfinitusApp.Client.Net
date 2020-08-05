using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Voucher
{
    public class VoucherCampaignConfigToUse
    {
        public VoucherCampaignConfigToUse()
        {
            OnlyUseBy = new VoucherCampaignConfigToUseOnlyUseBy();
            OnlyUseOn = new VoucherCampaignConfigToUseOnlyUseOn();
        }

        public VoucherCampaignConfigToUseOnlyUseBy OnlyUseBy { get; set; }

        public VoucherCampaignConfigToUseOnlyUseOn OnlyUseOn { get; set; }

        /// <summary>
        /// Don't set it to not expires
        /// </summary>
        public DateTime? ExpiresAt { get; set; }

        public bool HasExpiration => ExpiresAt.HasValue;
    }

    public class VoucherCampaignConfigToUseOnlyUseBy
    {
        public VoucherCampaignConfigToUseByType ReferenceType { get; set; }

        public string ReferenceId { get; set; }
    }

    public class VoucherCampaignConfigToUseOnlyUseOn
    {
        public VoucherCampaignConfigToUseOnType ReferenceType { get; set; }

        public string ReferenceId { get; set; }
    }

    public enum VoucherCampaignConfigToUseByType
    {
        Undefined,
        ApplicationUser
    }

    public enum VoucherCampaignConfigToUseOnType
    {
        Undefined,
        FinancialRequest,
    }
}

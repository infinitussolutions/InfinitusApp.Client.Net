using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Voucher
{
    public class VoucherCampaignConfig
    {
        public VoucherCampaignConfig()
        {
            ToGenerate = new VoucherCampaignConfigToGenerate();
            ToUse = new VoucherCampaignConfigToUse();
            CreditInfo = new VoucherCampaignConfigCreditInfo();
        }

        public VoucherCampaignConfigToGenerate ToGenerate { get; set; }

        public VoucherCampaignConfigToUse ToUse { get; set; }

        public VoucherCampaignConfigCreditInfo CreditInfo { get; set; }
    }

    public class VoucherCampaignConfigCreditInfo
    {
        public VoucherCampaignTypeToIdentityCreditInfoType Type { get; set; }

        public int Value { get; set; }

        public string ValuePresentation => Type == VoucherCampaignTypeToIdentityCreditInfoType.Price ? Value.ToString("C") : Value.ToString() + "%";

        public string ValueFromTypePresentation => Type == VoucherCampaignTypeToIdentityCreditInfoType.Price ? Value.ToString("N") : Value.ToString() + "%";

        public string CurrencySymbol => Type == VoucherCampaignTypeToIdentityCreditInfoType.Price ? NumberFormatInfo.CurrentInfo.CurrencySymbol : "";

        public string PercentMsg => Type == VoucherCampaignTypeToIdentityCreditInfoType.Percent ? "OFF" : "";
    }

    public enum VoucherCampaignTypeToIdentityCreditInfoType
    {
        Undefined,
        Price,
        Percent
    }
}

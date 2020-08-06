using System;
using System.Collections.Generic;
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

        public string ValuePresentation
        {
            get
            {
                switch (Type)
                {
                    case VoucherCampaignTypeToIdentityCreditInfoType.Price:
                        return Value.ToString("C");
                    case VoucherCampaignTypeToIdentityCreditInfoType.Percent:
                        return Value + "%";
                    case VoucherCampaignTypeToIdentityCreditInfoType.Undefined:
                    default:
                        return "";
                }
            }
        }
    }

    public enum VoucherCampaignTypeToIdentityCreditInfoType
    {
        Undefined,
        Price,
        Percent
    }
}

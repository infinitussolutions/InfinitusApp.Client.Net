using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Voucher
{
    public class VoucherCampaignConfigToGenerate
    {
        public VoucherCampaignConfigToGenerate()
        {
            GenerateCodeTo = new VoucherCampaignGenerateCodeTo();
        }

        public int Quantity { get; set; }

        public VoucherCampaignGenerateCodeTo GenerateCodeTo { get; set; }
    }

    public class VoucherCampaignGenerateCodeTo
    {
        public VoucherCampaignToGenerateCodeToType ToType { get; set; }

        public string ReferenceId { get; set; }

        public bool ReferenceIdIsValid =>
            ToType != VoucherCampaignToGenerateCodeToType.AddAStaticCode &&
            ToType != VoucherCampaignToGenerateCodeToType.FavoriteADataItem || !string.IsNullOrEmpty(ReferenceId)
            ;
    }

    public enum VoucherCampaignToGenerateCodeToType
    {
        Undefined,
        AddARandomCode,
        AddAStaticCode,
        FavoriteADataItem,
        Draw
    }
}

using InfinitusApp.Core.Data.DataModels.Fidelity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Voucher
{
    public class VoucherGenerate : Naylah.Core.Entities.EntityBase
    {
        public string Code { get; set; }

        public DateTimeOffset? UsedAt { get; set; }

        #region Relations

        public VoucherCampaign VoucherCampaign { get; set; }

        public string VoucherCampaignId { get; set; }

        public DataStore DataStore { get; set; }

        public string DataStoreId { get; set; }

        #endregion

        #region Action

        public FinancialRequest UsedOnFinancialRequest { get; set; }

        public string UsedOnFinancialRequestId { get; set; }

        public ApplicationUser UsedByApplicationUser { get; set; }

        public string UsedByApplicationUserId { get; set; }

        #endregion

        #region Helpers

        [JsonIgnore]
        public string CodeAndValue => Code + "(" + CreditValue.ToString("C") + ")";

        [JsonIgnore]
        public string Emoji { get; set; }

        [JsonIgnore]
        public string CreateAtPresentation => CreatedAt.HasValue ? CreatedAt.Value.ToString("dd MMMM") : "";

        [JsonIgnore]
        public string ValidAtPresentation => !(ExpiresAt == DateTime.MaxValue) ? ExpiresAt.ToString("dd MMMM") : "";

        [JsonIgnore]
        public bool IsUsed => UsedAt.HasValue;

        [JsonIgnore]
        public bool IsExpires => DateTime.Now.Date > ExpiresAt;

        [JsonIgnore]
        public bool IsUsedOrExpires => IsUsed || IsExpires;

        [JsonIgnore]
        public VoucherCampaignTypeToIdentityCreditInfoType CreditType => VoucherCampaign != null ? VoucherCampaign.Config.CreditInfo.Type : VoucherCampaignTypeToIdentityCreditInfoType.Undefined;

        [JsonIgnore]
        public int CreditValue => VoucherCampaign != null ? VoucherCampaign.Config.CreditInfo.Value : 0;

        [JsonIgnore]
        public DateTime ExpiresAt => VoucherCampaign != null ? VoucherCampaign.Config.ToUse.ExpiresAt.HasValue ? VoucherCampaign.Config.ToUse.ExpiresAt.Value.Date : DateTime.MaxValue : DateTime.MaxValue;

        [JsonIgnore]
        public string CanAddOnlyFinancialRequestId => VoucherCampaign != null ? VoucherCampaign.Config.ToUse.OnlyUseOn.ReferenceType == VoucherCampaignConfigToUseOnType.FinancialRequest ? VoucherCampaign.Config.ToUse.OnlyUseOn.ReferenceId : "" : "";

        [JsonIgnore]
        public string CanUsedOnlyByApplicationUserId => VoucherCampaign != null ? VoucherCampaign.Config.ToUse.OnlyUseBy.ReferenceType == VoucherCampaignConfigToUseByType.ApplicationUser ? VoucherCampaign.Config.ToUse.OnlyUseBy.ReferenceId : "" : "";

        [JsonIgnore]
        public bool HasRestriction => !string.IsNullOrEmpty(CanAddOnlyFinancialRequestId) || !string.IsNullOrEmpty(CanUsedOnlyByApplicationUserId);

        #endregion
    }

    public static class VoucherGenerateExtention
    {
        public static decimal ApplyDiscountOnValue(this VoucherGenerate voucher, decimal value)
        {
            switch (voucher.CreditType)
            {
                case VoucherCampaignTypeToIdentityCreditInfoType.Price:
                    return value - voucher.CreditValue;
                case VoucherCampaignTypeToIdentityCreditInfoType.Percent:
                    return value - ((voucher.CreditValue * value) / 100);
            }

            return 0;
        }

        public static decimal GetDiscountOnValue(this VoucherGenerate voucher, decimal value)
        {
            switch (voucher.CreditType)
            {
                case VoucherCampaignTypeToIdentityCreditInfoType.Price:
                    return voucher.CreditValue;
                case VoucherCampaignTypeToIdentityCreditInfoType.Percent:
                    return (voucher.CreditValue * value) / 100;
            }

            return 0;
        }
    }
}

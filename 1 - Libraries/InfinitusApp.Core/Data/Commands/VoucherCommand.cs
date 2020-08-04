using InfinitusApp.Core.Data.DataModels.Voucher;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    class VoucherCommand
    {
    }

    public class VoucherCampaignCommand
    {
        public string Title { get; set; }

        public VoucherCampaignConfig Config { get; set; }
    }

    public class CreateVoucherCampanignCommand : VoucherCampaignCommand
    {

        public string ParentDataItemId { get; set; }

        public string MsgItIsNotValid
        {
            get
            {
                var msg = "";

                //if (string.IsNullOrEmpty(ParentDataItemId))
                //    msg += "- " + nameof(ParentDataItemId) + " is not valid\n";

                if (string.IsNullOrEmpty(Title))
                    msg += "- " + nameof(Title) + " is not valid\n";

                if (Config == null)
                    msg += "- " + nameof(Config) + " is not valid\n";

                else
                {
                    if (Config.ToGenerate.GenerateCodeTo.ToType == VoucherCampaignToGenerateCodeToType.Undefined)
                        msg += "- Config to generate code is not valid\n";

                    if (Config.CreditInfo.Type == VoucherCampaignTypeToIdentityCreditInfoType.Undefined)
                        msg += "- Credit info Config is not valid\n";

                    else
                    {
                        if (Config.CreditInfo.Type == VoucherCampaignTypeToIdentityCreditInfoType.Percent && Config.CreditInfo.Value > 100)
                            msg += "- Credit info config to percent is not valid\n";
                    }
                }

                return msg;
            }
        }
    }

    public class UpdateVoucherCampaignCommand : VoucherCampaignCommand
    {
        public string Id { get; set; }

        public string MsgItIsNotValid
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Id))
                    msg += "- " + nameof(Id) + " is not valid\n";

                return msg;
            }
        }
    }
}

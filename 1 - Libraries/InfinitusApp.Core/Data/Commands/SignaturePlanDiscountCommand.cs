using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.Signature.SignaturePlanDiscount;

namespace InfinitusApp.Core.Data.Commands
{
    public class SignaturePlanDiscountCommand
    {
        public decimal Discount { get; set; }

        public string Observation { get; set; }
    }

    public class CreateSignaturePlanDiscountCommand : SignaturePlanDiscountCommand
    {
        public DateTimeOffset ValidUntil { get; set; }
        public string SignaturePlanApplicationUserId { get; set; }
        public SignaturePlanDiscountType Type { get; set; }
    }

    public class UpdateSignaturePlanDiscountCommand : SignaturePlanDiscountCommand
    {
        public string Id { get; set; }
        public DateTimeOffset? ValidUntil { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Price
    {
        public Price()
        {
            Discount = new Discount();
            ExtraCharge = new ExtraCharge();
        }

        public decimal InitialPrice { get; set; }

        public Discount Discount { get; set; }

        public ExtraCharge ExtraCharge { get; set; }

        public decimal TotalDiscount
        {
            get
            {
                if (Discount.DiscountInPercent > 0)
                {
                    var discount = (InitialPrice * Discount.DiscountInPercent) / 100;
                    return discount < InitialPrice ? discount : 0;
                }

                if (Discount.DiscountInMoney > 0)
                {
                    return Discount.DiscountInMoney <= InitialPrice ? Discount.DiscountInMoney : 0;
                }

                return 0;
            }
        }

        public decimal TotalExtraCharge
        {
            get
            {
                if (ExtraCharge == null)
                    return 0;

                if (ExtraCharge.InPercent > 0)
                    return (InitialPrice * ExtraCharge.InPercent) / 100;


                if (ExtraCharge.InMoney > 0)
                    return ExtraCharge.InMoney;

                return 0;
            }
        }

        public decimal FinalPrice
        {
            get
            {
                return (InitialPrice + TotalExtraCharge) - TotalDiscount;
            }
        }

        public string FinalPricePresentation
        {
            get
            {
                return FinalPrice.ToString("C");
            }
        }
    }

    public class Discount
    {
        public decimal DiscountInMoney { get; set; }

        public decimal DiscountInPercent { get; set; }
    }

    public class ExtraCharge
    {
        public decimal InMoney { get; set; }
        public decimal InPercent { get; set; }
    }
}

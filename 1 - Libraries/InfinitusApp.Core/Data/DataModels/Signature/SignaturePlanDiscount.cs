using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Signature
{
    public class SignaturePlanDiscount : EntityBase
    {
        public SignaturePlanDiscount()
        {

        }

        public decimal Discount { get; set; }
        public DateTimeOffset ValidUntil { get; set; }
        public SignaturePlanDiscountType Type { get; set; }
        public string Observation { get; set; }

        #region Relations

        public SignaturePlanApplicationUser SignaturePlanApplicationUser { get; set; }
        public string SignaturePlanApplicationUserId { get; set; }

        #endregion

        #region Helps

        public string TypePresentation 
        {
            get
            {
                switch (Type)
                {
                    case SignaturePlanDiscountType.Plan:
                        return "Plano";

                    case SignaturePlanDiscountType.FinancialRequestPrice:
                        return "Pedidos de venda";

                    case SignaturePlanDiscountType.BookingPrice:
                        return "Reservas";

                    case SignaturePlanDiscountType.PushNotificationPrice:
                        return "Notificações";

                    default:
                        return string.Empty;
                }
            }
        }

        #endregion

        public enum SignaturePlanDiscountType
        {
            Plan,
            FinancialRequestPrice,
            BookingPrice,
            PushNotificationPrice
        }

    }
}

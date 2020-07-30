using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu
{
    public class PaymentCommand
    {
        public string SubscriptionId { get; set; }

        /// <summary>
        /// if informed, SubscriptionId is not required
        /// </summary>
        public IuguPaymentAccountInfo IuguAccountInfo { get; set; }
    }

    public class IuguPaymentAccountInfo
    {
        public string AccountId { get; set; }

        public string ApiToken { get; set; }
    }

    public class PayWithCreditCardCommand : PaymentCommand
    {
        public string IuguInvoiceId { get; set; }

        public string InternalInvoiceId { get; set; }

        public string SalesOrderId { get; set; }

        public PaymentTokenCommand CreditCardInfo { get; set; }
    }
}

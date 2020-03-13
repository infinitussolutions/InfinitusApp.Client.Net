using Ebanx.net.Commands.PaymentApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Ebanx
{
    public class EbanxDirectPaymentCommand
    {
        public string FinancialRequestId { get; set; }
        public DirectCommand DirectCommand { get; set; }
    }
}

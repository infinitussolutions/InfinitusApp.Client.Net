﻿using Ebanx.net.Parameters.Requests.DirectOperation;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Ebanx
{
    public class EbanxDirectPaymentCommand
    {
        public string FinancialRequestId { get; set; }
        public DirectRequest DirectCommand { get; set; }
        public string MarketplaceId { get; set; }
    }
}

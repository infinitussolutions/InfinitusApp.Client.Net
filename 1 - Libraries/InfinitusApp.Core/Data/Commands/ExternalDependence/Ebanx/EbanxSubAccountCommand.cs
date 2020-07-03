using Ebanx.net.Parameters.Requests.Affiliate;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Ebanx
{
    public class EbanxSubAccountCommand
    {
        public EbanxSubAccountCommand()
        {
            Request = new CreateRequest();
        }

        public CreateRequest Request { get; set; }
        public string MarketplaceId { get; set; }
    }
}

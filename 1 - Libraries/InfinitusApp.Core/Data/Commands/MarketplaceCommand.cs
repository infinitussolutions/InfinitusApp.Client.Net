using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class MarketplaceCommand
    {


    }

    public class CreateMarketplaceCommand : MarketplaceCommand
    {
        public string DataStoreId { get; set; }
    }

    public class UpdateMarketplaceCommand : MarketplaceCommand
    {
        public PaymentInfo PaymentInfo { get; set; }

        public InvoiceConfig InvoiceConfig { get; set; }

        public IuguMarketplace Iugu { get; set; }

        public EbanxMarketplace Ebanx { get; set; }

        public InfinitusMarketplaceConfig InfinitusConfig { get; set; }

        public string DefaultFinancialOriginId { get; set; }

        public string DefaultCustomerId { get; set; }

        public string SalesmanUserId { get; set; }

        public string Id { get; set; }
    }
}

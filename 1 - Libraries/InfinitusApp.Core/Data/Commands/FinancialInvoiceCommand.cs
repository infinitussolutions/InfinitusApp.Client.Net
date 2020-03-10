using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class FinancialInvoiceCommand
    {
        public InvoiceInstallmentmentStatus Status { get; set; }
        public string Description { get; set; }

        public DateTimeOffset? SettlementDate { get; set; }
    }

    public class FinancialInvoiceCreateCommand : FinancialInvoiceCommand
    {
        public string FinancialRequestId { get; set; }
        public ExternalReference ExternalReference { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public int InstallmentNumber { get; set; }

        public Price InstallmentPrice { get; set; }

        public string DataStoreId { get; set; }
    }

    public class FinancialInvoiceUpdateCommand : FinancialInvoiceCommand
    {
        public string Id { get; set; }
    }

  
}

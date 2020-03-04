using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class FinancialInvoiceCommand
    {

    }

    public class FinancialInvoiceUpdateCommand : FinancialInvoiceCommand
    {
        public string Id { get; set; }
        public InvoiceInstallmentmentStatus Status { get; set; }
    }

    public class FinancialInvoiceGetCommand
    {
        public string DataStoreId { get; set; }
        public DateTimeOffset? InitialDate { get; set; }
        public DateTimeOffset FinalDate { get; set; }
    }
}

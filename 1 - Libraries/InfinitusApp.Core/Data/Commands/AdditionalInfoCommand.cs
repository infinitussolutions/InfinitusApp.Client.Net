using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class AdditionalInfoCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class AdditionalInfoCreateCommand : AdditionalInfoCommand
    {
        public string AppointmentId { get; set; }
        public string FinancialRequestId { get; set; }
        public string FinancialInvoiceId { get; set; }
    }

    public class AdditionalInfoUpdateCommand : AdditionalInfoCommand
    {
        public string Id { get; set; }
    }
}

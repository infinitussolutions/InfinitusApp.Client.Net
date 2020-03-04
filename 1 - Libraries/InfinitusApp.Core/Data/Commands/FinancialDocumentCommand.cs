
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.Commands
{

    public class FinancialDocumentCommand
    {
        public string Note { get; set; }

        public string FinancialTellerId { get; set; }

        //public string FinancialTypeId { get; set; }
    }

    public class CreateFinancialDocumentCommand : FinancialDocumentCommand
    {
        public string FinancialRequestId { get; set; }
    }

    public class UpdateFinancialDocumentCommand : FinancialDocumentCommand
    {
        public string Id { get; set; }

        public string FinancialOriginId { get; set; }
    }

    public class CanceledFinancialDocumentCommand
    {
        public string Id { get; set; }

        public string Motive { get; set; }

        public string UserId { get; set; }
    }
}

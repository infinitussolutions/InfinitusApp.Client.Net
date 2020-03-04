using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class BankSlip
    {

        public string ExternalId { get; set; }

        public string Url { get; set; }

        public int TransactionNumber { get; set; }

        public string DigitableLine { get; set; }

        public string Barcode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Custom.SpringerCarrier
{
    public class SpringerCarrierInvoice
    {
        public SpringerCarrierInvoice()
        {
            Date = DateTime.Now;
        }

        public string Number { get; set; }
        public DateTime Date { get; set; }
    }
}

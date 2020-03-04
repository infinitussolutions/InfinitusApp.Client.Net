using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Custom.SpringerCarrier
{
    public class SpringerCarrierServiceOrder
    {
        public SpringerCarrierServiceOrder()
        {
            Invoice = new SpringerCarrierInvoice();
            Items = new List<SpringerCarrierItem>();
            Audios = new List<AudioFile>();
            Images = new List<string>();
        }

        public string Observation { get; set; }

        public IList<AudioFile> Audios { get; set; }

        public IList<string> Images { get; set; }

        public SpringerCarrierInvoice Invoice { get; set; }

        public SpringerCarrierServiceOrderStatus Status { get; set; }

        public IList<SpringerCarrierItem> Items { get; set; }

        public bool InWarranty { get; set; }
        public bool CorrectInstallation { get; set; }

        public enum SpringerCarrierServiceOrderStatus
        {
            Pending,
            Complete
        }
    }


}

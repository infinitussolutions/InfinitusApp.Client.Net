using InfinitusApp.Core.Data.DataModels.External.Iugu;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ExternalModel
    {
        public ExternalModel()
        {
            Iugu = new Iugu();
        }

        public Iugu Iugu { get; set; }
    }

    public class Iugu
    {
        public Iugu()
        {
            Invoice = new IuguInvoice();
        }

        public IuguInvoice Invoice { get; set; }
    }
}

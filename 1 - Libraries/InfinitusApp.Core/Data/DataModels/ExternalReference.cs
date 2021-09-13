using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ExternalReference
    {
        public ExternalReference()
        {
            ExternalType = ExternalReferenceType.Undefined;
        }

        public ExternalReferenceType ExternalType { get; set; }

        public string ReferenceId { get; set; }

        public string PaymentUrl { get; set; }
    }

    public enum ExternalReferenceType
    {
        Undefined,
        Iugu,
        Ebanx
    }
}

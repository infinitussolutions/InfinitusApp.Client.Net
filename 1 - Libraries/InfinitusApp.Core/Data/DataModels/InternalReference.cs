using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class InternalReference
    {
        public InternalReference()
        {
            InternalType = ReferenceItemType.Undefined;
        }

        public ReferenceItemType InternalType { get; set; }

        public string ReferenceId { get; set; }
    }

    public enum ReferenceItemType
    {
        Undefined,
        DataItem
    }
}

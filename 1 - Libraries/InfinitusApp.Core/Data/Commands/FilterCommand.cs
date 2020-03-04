using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class FilterCommand
    {
        public string DataStoreId { get; set; }
        public FilterField Field { get; set; }
        public string ValueToFilter { get; set; }

        public enum FilterField
        {
            Unknown,
            PartialName,
            ExactName,
            IdentityDocument,
            Email
        }

    }
}

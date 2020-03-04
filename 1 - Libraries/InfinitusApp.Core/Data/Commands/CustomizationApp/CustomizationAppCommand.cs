using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.CustomizationApp
{
    public class CustomizationAppCommand
    {
        public string DataStoreId { get; set; }
        public string ReferencyId { get; set; }
        public ReferencyDescription ReferencyDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Custom.SpringerCarrier
{
    public class SpringerCarrierItem
    {
        public SpringerCarrierItem()
        {
            Price = new Price();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }
    }
}

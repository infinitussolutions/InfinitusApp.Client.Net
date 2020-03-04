using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Subscription : EntityBase
    {
        public Subscription()
        {
            MarketplaceData = new MarketplaceData();
        }

        public string Name { get; set; }

        public DateTime OpeningDate { get; set; }

        public MarketplaceData MarketplaceData { get; set; }
    }
}

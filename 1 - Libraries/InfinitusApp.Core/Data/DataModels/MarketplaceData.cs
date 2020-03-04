using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class MarketplaceData
    {
        public MarketplaceData()
        {
            Properties = new List<string>();
        }

        public string ExternalId { get; set; }

        //Ficam as chaves
        public List<string> Properties { get; set; }

        public MarketplaceDataStatus Status { get; set; } = MarketplaceDataStatus.Pending;
    }

    public enum MarketplaceDataStatus
    {
        Deactivated,
        Pending,
        Active,
    }
}

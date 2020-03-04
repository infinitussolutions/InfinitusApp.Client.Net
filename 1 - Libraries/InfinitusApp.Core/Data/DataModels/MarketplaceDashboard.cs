namespace InfinitusApp.Core.Data.DataModels
{
    public class MarketplaceDashboard
    {
        public MarketplaceDashboard()
        {

        }

        public string LastWithdraw { get; set; }

        public int TotalSubscriptions { get; set; }

        public string Balance { get; set; }

        public string ProtectedBalance { get; set; }

        public string PayableBalance { get; set; }

        public string ReceivableBalance { get; set; }

        public string CommissionBalance { get; set; }

        public string VolumeLastMonth { get; set; }

        public string VolumeThisMonth { get; set; }

        public string TaxesPaidLastMonth { get; set; }

        public string TaxesPaidThisMonth { get; set; }

        public string Name { get; set; }
    }
}

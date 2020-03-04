namespace InfinitusApp.Core.Data.DataModels
{
    public class PaymentMethod : Naylah.Core.Entities.EntityBase
    {
        public string Description { get; set; }

        public string ExternalReference { get; set; }

        public string DataStoreId { get; set; }
    }
}
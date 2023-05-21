using Naylah.Core.Entities;

namespace InfinitusApp.Core.Data.DataModels
{
    public class CustomerZoneRelation : EntityBase
    {
        public CustomerZoneRelation()
        {

        }
        public CustomerZoneRelationType Type { get; set; }
        public virtual DataStore DataStore { get; set; }
        public virtual string DataStoreId { get; set; }
        public virtual CustomerZone CustomerZone { get; set; }
        public virtual string CustomerZoneId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual string ApplicationUserId { get; set; }

        public enum CustomerZoneRelationType
        {
            Unknown,
            Seller,
            Manager

        }
    }
}

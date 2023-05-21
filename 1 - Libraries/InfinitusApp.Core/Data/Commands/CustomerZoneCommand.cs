using static InfinitusApp.Core.Data.DataModels.CustomerZoneRelation;

namespace InfinitusApp.Core.Data.Commands
{
    public class CustomerZoneCommand
    {
        public string Name { get; set; }
        public string InitialZipCode { get; set; }
        public string FinalZipCode { get; set; }
    }

    public class CreateCustomerZoneCommand : CustomerZoneCommand
    {
        public string DataStoreId { get; set; }
    }

    public class UpdateCustomerZoneCommand : CustomerZoneCommand
    {
        public string Id { get; set; }
    }

    public class CustomerZoneRelationCommand
    {
        public CustomerZoneRelationType Type { get; set; }
    }

    public class CustomerZoneRelationCreateCommand : CustomerZoneRelationCommand
    {
        public string DataStoreId { get; set; }
        public string CustomerZoneId { get; set; }
        public string ApplicationUserId { get; set; }
    }

    public class CustomerZoneRelationUpdateCommand : CustomerZoneRelationCommand
    {
        public string Id { get; set; }
    }
}

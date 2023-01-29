namespace InfinitusApp.Core.Data.Commands
{
    public class CustomerZoneCommand
    {
        public string Name { get; set; }
    }

    public class CreateCustomerZoneCommand : CustomerZoneCommand
    {
        public string DataStoreId { get; set; }
    }

    public class UpdateCustomerZoneCommand : CustomerZoneCommand
    {
        public string Id { get; set; }
    }
}

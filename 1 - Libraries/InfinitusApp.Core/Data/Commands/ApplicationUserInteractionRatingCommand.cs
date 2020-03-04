namespace InfinitusApp.Core.Data.Commands
{
    public class ApplicationUserInteractionRatingCommand
    {
        public string Comment { get; set; }

        public double Value { get; set; }
    }

    public class ApplicationUserInteractionRatingCreateCommand : ApplicationUserInteractionRatingCommand
    {
        public string ApplicationUserId { get; set; }

        public string DataItemId { get; set; }

        public string DataStoreId { get; set; }
    }

    public class ApplicationUserInteractionRatingUpdateCommand : ApplicationUserInteractionRatingCommand
    {
        public string Id { get; set; }
    }
}

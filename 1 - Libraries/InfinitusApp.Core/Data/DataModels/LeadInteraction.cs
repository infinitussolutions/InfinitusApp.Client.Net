namespace InfinitusApp.Core.Data.DataModels
{
    public class LeadInteractionBase : Naylah.Core.Entities.EntityBase
    {
        public string Content { get; set; }

        public string LeadId { get; set; }

        public string OperatorId { get; set; }

        public Naylah.Core.Entities.Identity.User Operator { get; set; }
    }

    public class LeadInteraction : LeadInteractionBase
    {
        public Lead Lead { get; set; }
    }
}
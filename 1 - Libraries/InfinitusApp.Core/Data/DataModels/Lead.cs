using System.Collections.Generic;

namespace InfinitusApp.Core.Data.DataModels
{
    public enum Status
    {
        None,
        Open,
        Ongoing,
        SaleAccomplished,
        LostSale
    }

    public class Lead : Naylah.Core.Entities.EntityBase
    {
        public Lead()
        {
            Interactions = new List<LeadInteractionBase>();
        }

        public Status Status { get; set; }

        public string Observation { get; set; }

        #region

        public string InterestedUserApplicationId { get; set; }

        public IList<LeadInteractionBase> Interactions { get; set; }

        public ApplicationUser InterestedUser { get; set; }

        public string InterestedUserApplicationUserId { get; set; }

        public DataItem InterestedItem { get; set; }

        public string InterestedItemId { get; set; }

        public string OperatorId { get; set; }

        public Naylah.Core.Entities.Identity.User Operator { get; set; }

        public DataStore DataStore { get; set; }

        public string DataStoreId { get; set; }

        #endregion
    }

    public class LeadCommand
    {
        public string Observation { get; set; }

        public string OperatorId { get; set; }
    }

    public class CreateLeadCommand : LeadCommand
    {
        public string DataStoreId { get; set; }

        public Status Status { get; set; }
        public string InterestedUserApplicationId { get; set; }

        public string InterestedUserApplicationUserId { get; set; }

        public string InterestedItemId { get; set; }
    }
}
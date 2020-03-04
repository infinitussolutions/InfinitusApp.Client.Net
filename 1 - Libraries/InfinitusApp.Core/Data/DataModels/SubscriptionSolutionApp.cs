using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public enum SubscriptionSolutionStatus
    {
        None,
        Pending,
        Actived,
        Canceled,
        Expired
    }

    public class SubscriptionSolutionApp : EntityBase
    {
        public SubscriptionSolutionApp()
        {
            AcquiredIn = DateTime.UtcNow;
            ExpirationIn = DateTime.UtcNow.AddYears(99);
        }

        public string Name { get; set; }
        
        public virtual SolutionApp Solution { get; set; }

        public DateTime? AcquiredIn { get; set; }

        public DateTime? ExpirationIn { get; set; }

        public SubscriptionSolutionStatus Status { get; set; }

        public string ExtensionReferenceId { get; set; }

        public string SubscriptionId { get; set; }

        public string SolutionId { get; set; }
    }
}

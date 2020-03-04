using Naylah.Core.Entities;

namespace InfinitusApp.Core.Data.DataModels
{
    public class CollaboratorUserLevel : EntityBase
    {
        public CollaboratorUserLevelType Level { get; set; }

        public CollaboratorUserLevelIdentityReference IdentityReference { get; set; }

        public string Identity { get; set; }

        #region Relation

        public virtual DataItem DataItem { get; set; }

        public virtual string DataItemId { get; set; }

        #endregion
    }

    public enum CollaboratorUserLevelIdentityReference
    {
        Id,
        Email
    }

    public enum CollaboratorUserLevelType
    {
        Undefined,
        Owner,
        Manager,
        StakeHolder
    }
}

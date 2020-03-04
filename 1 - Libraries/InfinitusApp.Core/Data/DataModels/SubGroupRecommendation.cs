using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class SubGroupRecommendation : EntityBase
    {
        public SubGroupRelationType SubGroupRelationType { get; set; }

        #region Relations

        public DataItem DataItem { get; set; }

        public string DataItemId { get; set; }

        public SubGroup SubGroup { get; set; }

        public string SubGroupId { get; set; }

        #endregion
    }

    public enum SubGroupRelationType
    {
        None,
        Required,
        Recommended
    }
}


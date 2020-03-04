using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class GroupBase : EntityBase
    {
        public GroupBase()
        {
            DataItems = new List<DataItem>();
        }

        public string Title { get; set; }

        public string Type { get; set; }

        public string ImageUri { get; set; }

        #region Relations

        public IList<DataItem> DataItems { get; set; }

        #endregion
    }
    public class Group : GroupBase
    {
        public Group()
        {
            SubGroups = new List<SubGroup>();
        }

        public IList<SubGroup> SubGroups { get; set; }

    }
}

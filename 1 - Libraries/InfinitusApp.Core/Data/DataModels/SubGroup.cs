using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class SubGroup : GroupBase
    {
        public SubGroup()
        {

        }

        #region Relations

        public Group Group { get; set; }
        public string GroupId { get; set; }

        #endregion
    }
}

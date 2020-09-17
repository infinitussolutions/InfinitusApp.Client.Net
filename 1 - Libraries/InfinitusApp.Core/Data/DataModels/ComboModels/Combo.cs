using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.ComboModels
{
    public class Combo : EntityBase
    {
        public Combo()
        {
            Categories = new List<ComboCategory>();
            StartPrice = new Price();
        }

        public string Title { get; set; }

        public Price StartPrice { get; set; }

        #region Relations

        public List<ComboCategory> Categories { get; set; }

        public string DataStoreId { get; set; }

        public DataItem Parent { get; set; }

        public string ParentId { get; set; }

        #endregion
    }
}

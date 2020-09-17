using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.ComboModels
{
    public class ComboCategory : EntityBase
    {
        public ComboCategory()
        {
            Items = new List<ComboItem>();
        }

        public string Title { get; set; }

        public int QuantityRequired { get; set; }

        #region Relations

        public List<ComboItem> Items { get; set; }

        public Combo Combo { get; set; }

        public string ComboId { get; set; }

        #endregion
    }
}

using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [JsonIgnore]
        public bool IsCompleted => Items.Where(x => x.Quantity > 0).Count().Equals(QuantityRequired);

        [JsonIgnore]
        public string SelectedTitle => "SELECIONE " + QuantityRequired + " " + Title.ToUpper();
    }
}

using InfinitusApp.Core.Shared;
using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.ComboModels
{
    public class ComboCategory : EntityObservableBase
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
        public int QuantityAdded => Items.Sum(x => x.Quantity);

        [JsonIgnore]
        public bool IsCompleted => QuantityRequired.Equals(QuantityAdded);  //Items.Where(x => x.Quantity > 0).Count().Equals(QuantityRequired);

        [JsonIgnore]
        private string _selectedTitlePresentation;
        public string SelectedTitlePresentation
        {
            get { return _selectedTitlePresentation; }
            set { Set(ref _selectedTitlePresentation, value); }
        }

        public void RaisePresentation()
        {
            SelectedTitlePresentation = "SELECIONE " + QuantityAdded + "\\" + QuantityRequired;
        }
    }
}

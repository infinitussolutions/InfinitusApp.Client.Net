using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.ComboModels
{
    public class ComboItem : EntityBase
    {
        public ComboItem()
        {
            ExtraPrice = new Price();
        }

        public Price ExtraPrice { get; set; }

        public DataItem DataItem { get; set; }

        public string DataItemId { get; set; }

        public ComboCategory ComboCategory { get; set; }

        public string ComboCategoryId { get; set; }

        [JsonIgnore]
        public string Title 
        {
            get
            {
                if (string.IsNullOrEmpty(DataItemId))
                    return "Novo item";

                if (DataItem == null)
                    return "Null";

                return DataItem.Description.Title;
            }
        }

        [JsonIgnore]
        public string Description => DataItem?.Description?.Body ?? "";

        [JsonIgnore]
        public int Quantity { get; set; }
    }
}

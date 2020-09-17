using Naylah.Core.Entities;
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
    }
}

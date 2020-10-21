using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        [JsonIgnore]
        public bool IsCompleted => Categories.Where(x => !x.IsCompleted) == null || Categories.Where(x => !x.IsCompleted).Equals(0);
    }
}

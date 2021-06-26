using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class DataItemRelation : Naylah.Core.Entities.EntityBase
    {
        public DataItemRelation()
        {

        }

        public DataItem DataItemFrom { get; set; }
        public string DataItemFromId { get; set; }
        public DataItem DataItemTo { get; set; }
        public string DataItemToId { get; set; }
        public DataItemRelationType RelationType { get; set; }

        public enum DataItemRelationType
        {
            Undefined,
            Recomended
        }
    }
}

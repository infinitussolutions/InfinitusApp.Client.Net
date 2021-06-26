using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.DataItemRelation;

namespace InfinitusApp.Core.Data.Commands.DataItem
{
    public class DataItemRelationCommand
    {
        public DataItemRelationType RelationType { get; set; }
    }

    public class CreateDataItemRelationCommand : DataItemRelationCommand
    {
        public string DataItemFromId { get; set; }
        public string DataItemToId { get; set; }

    }

    public class UpdateDataItemRelationCommand : DataItemRelationCommand
    {
        public string Id { get; set; }

    }
}

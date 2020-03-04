using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.TagDataItemRelation;

namespace InfinitusApp.Core.Data.Commands
{
    public class TagDataItemRelationCommand
    {
        public TagDataItemRelationType RelationType { get; set; }
    }

    public class TagDataItemRelationCreateCommand : TagDataItemRelationCommand
    {
        public string TagId { get; set; }

        public string DataItemId { get; set; }
    }

    public class TagDataItemRelationUpdateCommand : TagDataItemRelationCommand
    {
        public string Id { get; set; }
    }


    public class TagTagRelationCommand
    {
        public string TagId { get; set; }

        public string ChildTagId { get; set; }
    }

    public class TagTagCreateRelationCommand : TagTagRelationCommand
    {

    }
}
//    public class TagRelationCommand
//    {
//        public TagRelationType RelationType { get; set; }
//    }

//    public class TagRelationCreateCommand : TagRelationCommand
//    {
//        public string TagId { get; set; }
//        public string DataItemId { get; set; }
//        public string ChildTagId { get; set; }
//    }

//    public class TagRelationUpdateCommand : TagRelationCommand
//    {
//        public string Id { get; set; }
//    }
//}

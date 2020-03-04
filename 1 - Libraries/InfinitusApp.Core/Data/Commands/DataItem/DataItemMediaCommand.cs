using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.DataItem
{
    public class DataItemMediaCommand
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public SpecialMedia SpecialMediaType { get; set; }
    }

    public class CreateDataItemMediaCommand : DataItemMediaCommand
    {
        public string DataItemId { get; set; }

        public string ResourceUri { get; set; }

        public DataItemMediaType DataItemMediaType { get; set; }
    }

    public class UpdateDataItemMediaCommand : DataItemMediaCommand
    {
        public string Id { get; set; }
    }
}

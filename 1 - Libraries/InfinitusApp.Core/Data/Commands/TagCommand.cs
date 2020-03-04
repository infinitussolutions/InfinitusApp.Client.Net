using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.Tag;

namespace InfinitusApp.Core.Data.Commands
{
    public class TagCommand
    {
        public TagPresentation Presentation { get; set; }

        public IList<string> DataItemIds { get; set; }

        public IList<string> TagIds { get; set; }

        public TagFinancialRequestOption FinancialRequestOption { get; set; }

        public TagNavigationOption NavigationOption { get; set; }
    }

    public class TagCreateCommand : TagCommand
    {
        public string DataStoreId { get; set; }
    }

    public class TagUpdateCommand : TagCommand
    {
        public string Id { get; set; }
    }
}

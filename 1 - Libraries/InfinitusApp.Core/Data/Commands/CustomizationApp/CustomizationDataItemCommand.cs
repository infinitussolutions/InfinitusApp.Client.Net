using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.CustomizationApp
{
    public class CustomizationDataItemCommand : CustomizationAppCommand
    {
        public DataItemPriceInfo DefaultPrice { get; set; }
        public CustomizationAgenda Agenda { get; set; }
    }

    public class CustomizationDataItemCreateCommand : CustomizationDataItemCommand
    {

    }

    public class CustomizationDataItemUpdateCommand : CustomizationDataItemCommand
    {
        public string Id { get; set; }
    }
}

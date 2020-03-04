using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.CustomizationApp
{
    public class CustomizationActionsCommand : CustomizationAppCommand
    {
        public ActionsCustomization Actions { get; set; }
    }

    public class CustomizationActionsCreateCommand : CustomizationActionsCommand
    {

    }

    public class CustomizationActionsUpdateCommand : CustomizationActionsCommand
    {
        public string Id { get; set; }
    }
}

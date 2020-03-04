using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Customization
{
    public class CustomizationAppUserProfileCommand
    {
        public bool Required { get; set; }
    }

    public class CustomizationAppUserProfileCreateCommand : CustomizationAppUserProfileCommand
    {
        public ProfileField Type { get; set; }
        public string ApplicationId { get; set; }
    }

    public class CustomizationAppUserProfileUpdateCommand : CustomizationAppUserProfileCommand
    {
        public string Id { get; set; }
        public bool Visible { get; set; }
    }
}

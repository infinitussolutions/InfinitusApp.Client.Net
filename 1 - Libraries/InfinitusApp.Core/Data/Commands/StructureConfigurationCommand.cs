using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.StructureConfiguration;

namespace InfinitusApp.Core.Data.Commands
{
    public class StructureConfigurationCommand
    {
        public string Title { get; set; }

        public int Index { get; set; }

        public FontIcon Icon { get; set; }

        public string ApplicationId { get; set; }

        public Target Target { get; set; }

        public TermsOfUse TermsOfUse { get; set; }

        public StructureType Type { get; set; }

        public IList<string> TargetGroups { get; set; }
    }

    public class CreateStructureConfigurationCommand : StructureConfigurationCommand
    {
        public StructurePosition Position { get; set; }
    }

    public class UpdateStructureConfigurationCommand : StructureConfigurationCommand
    {
        public string Id { get; set; }
    }

    public class DeleteStructureConfigurationCommand
    {
        public DeleteStructureConfigurationCommand()
        {
            ListId = new List<string>();
        }

        public string ApplicationId { get; set; }
        public IList<string> ListId { get; set; }
    }
}

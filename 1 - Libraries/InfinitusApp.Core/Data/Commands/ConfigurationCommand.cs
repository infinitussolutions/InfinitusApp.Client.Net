using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class ConfigurationCommand
    {
        public FinancialRequestConfiguration FinancialRequestConfiguration { get; set; }

        public FinancialDocumentConfiguration FinancialDocumentConfiguration { get; set; }

        public DataItemConfiguration DataItemConfiguration { get; set; }
    }

    public class SaveConfigurationCommand : ConfigurationCommand
    {
        public string DataStoreId { get; set; }
    }
}

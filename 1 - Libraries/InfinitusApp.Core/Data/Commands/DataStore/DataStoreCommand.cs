using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.DataStore
{
    public class DataStoreCommand
    {
        public FinancialParameters FinancialParameters { get; set; }
    }

    public class DataStoreUpdateCommand : DataStoreCommand
    {
        public string Id { get; set; }
    }
}

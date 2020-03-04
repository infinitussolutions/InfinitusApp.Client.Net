
using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.Commands
{
    public class FinancialTellerCommand
    {
        public string Name { get; set; }
    }

    public class CreateFinancialTellerCommand : FinancialTellerCommand
    {
        public string DataStoreId { get; set; }

        public FinancialTellerType Type { get; set; }
    }

    public class UpdateFinancialTellerCommand : FinancialTellerCommand
    {
        public string Id { get; set; }
        public bool Active { get; set; }
    }
}

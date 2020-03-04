
using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.Commands
{
    public class FinancialMovementBaseCommand
    {
        public string Name { get; set; }
    }

    public class CreateFinancialBaseCommand : FinancialMovementBaseCommand
    {
        public string DataStoreId { get; set; }

        public FinancialMovementType Type { get; set; }
    }

    public class UpdateFinancialBaseCommand : FinancialMovementBaseCommand
    {
        public string Id { get; set; }
        public bool Active { get; set; }
    }

    public class CreateFinancialOriginCommand : CreateFinancialBaseCommand
    {
        public string FinancialTypeId { get; set; }
    }

    public class UpdateFinancialOriginCommand : UpdateFinancialBaseCommand
    {

    }

    public class CreateFinancialTypeCommand : CreateFinancialBaseCommand
    {

    }

    public class UpdateFinancialTypeCommand : UpdateFinancialBaseCommand
    {

    }
}

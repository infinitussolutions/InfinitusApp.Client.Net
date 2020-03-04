using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialTeller : Naylah.Core.Entities.EntityBase
    {
        public string Name { get; set; }

        public FinancialTellerType Type { get; set; }

        public bool Active { get; set; }

        #region Relations

        public virtual IList<FinancialDocument> Invoices { get; set; }

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        #endregion
    }

    public enum FinancialTellerType
    {
        Treasury,
        Cashier,
        Bank
    }
}

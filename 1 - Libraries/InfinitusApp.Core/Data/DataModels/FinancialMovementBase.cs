using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialMovementBase : Naylah.Core.Entities.EntityBase
    {
        public FinancialMovementBase()
        {
            FinancialDocuments = new List<FinancialDocument>();
        }

        public FinancialMovementType Type { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        #region Relations

        public IList<FinancialDocument> FinancialDocuments { get; set; }

        public string DataStoreId { get; set; }

        #endregion
    }

    public class FinancialOrigin : FinancialMovementBase
    {
        public FinancialOrigin()
        {
            FinancialType = new FinancialType();
        }

        #region Relations

        public FinancialType FinancialType { get; set; }

        public string FinancialTypeId { get; set; }

        #endregion
    }

    public class FinancialType : FinancialMovementBase
    {
        public FinancialType()
        {
            FinancialOrigins = new List<FinancialOrigin>();
        }

        #region Relations

        public virtual IList<FinancialOrigin> FinancialOrigins { get; set; }

        #endregion
    }

    public enum FinancialMovementType
    {
        Receivable,
        Payable
    }
}

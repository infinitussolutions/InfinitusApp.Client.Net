using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Fidelity
{
    public class FidelityPlan : Naylah.Core.Entities.EntityBase
    {
        public FidelityPlan()
        {
            Benefit = new FidelityPlanBenefit();
            Config = new FidelityPlanConfig();
            FidelityCards = new List<FidelityCard>();
        }

        public FidelityPlanBenefit Benefit { get; set; }

        public FidelityPlanConfig Config { get; set; }

        #region Relations

        public virtual IList<FidelityCard> FidelityCards { get; set; }

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        public virtual DataItem DataItem { get; set; }

        public virtual string DataItemId { get; set; }

        #endregion

        #region Helper

        public string CardsInfoIcon
        {
            get
            {
                return "🙎‍ (" + FidelityCards?.Count + ")";
            }
        }

        public decimal ValueOnePoint { get { return Config.ExpenseForOnePoint / Benefit.NecessaryPoint; } }

        public string ValueOnePointPresentation { get { return "1 ponto = " + ValueOnePoint.ToString("C"); } }

        #endregion
    }

    public class FidelityPlanConfig
    {
        /// <summary>
        /// $ for 1 point
        /// </summary>
        public decimal ExpenseForOnePoint { get; set; }

        public string ExpenseForOnePointPresentation { get { return ExpenseForOnePoint.ToString("C"); } }

        //public string ExpenseForOnePointInfo { get { return "1 ponto = " + ExpenseForOnePointPresentation; } }
    }

    public class FidelityPlanBenefit
    {
        public string Description { get; set; }

        public int NecessaryPoint { get; set; }

        public string DataItemId { get; set; }
    }
}

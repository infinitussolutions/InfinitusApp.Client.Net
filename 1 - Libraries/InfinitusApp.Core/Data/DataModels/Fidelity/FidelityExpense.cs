using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Fidelity
{
    public class FidelityExpense : Naylah.Core.Entities.EntityBase
    {
        public FidelityExpense()
        {
            Expense = new Expense();
        }

        /// <summary>
        /// ApplicationUser or platform user Id
        /// </summary>
        public string ResponsibleUserId { get; set; }

        public string Description { get; set; }

        public Expense Expense { get; set; }

        public decimal Total
        {
            get
            {
                return IsInput ? Expense.InputInfo.Total : IsOutput ? Expense.OutPutInfo.Total : 0;
            }
        }

        public bool IsInput { get { return Expense?.InputInfo?.Total != null && Expense?.InputInfo?.Total > 0; } }

        public bool IsOutput { get { return Expense?.OutPutInfo?.Total != null && Expense?.OutPutInfo?.Total > 0; } }

        public string Color { get { return IsInput ? "#27ae60" : "#e74c3c"; } }

        #region Relations

        public FidelityCard FidelityCard { get; set; }

        public string FidelityCardId { get; set; }

        public string DataStoreId { get; set; }

        #endregion

        #region Helpers

        public string CompanyResponsible { get { return FidelityCard?.FidelityPlan?.DataItem?.Description?.Title; } }

        public string DateCreatePresentation { get { return CreatedAt.HasValue ? CreatedAt.Value.ToPresentation(true) : ""; } }

        public decimal PointInMoney { get { return (Total / FidelityCard.FidelityPlan.Config.ExpenseForOnePoint) * FidelityCard.FidelityPlan.ValueOnePoint; } }

        public string PointInMoneyPresentation { get { return (IsInput ? "+" : "-") + PointInMoney.ToString("C") + "! " + (IsInput ? EmojiExtention.GetARandomEmojiHappy : ""); } }

        #endregion

    }
}

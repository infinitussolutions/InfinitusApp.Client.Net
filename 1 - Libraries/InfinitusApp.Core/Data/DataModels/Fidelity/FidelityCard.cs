using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Fidelity
{
    public class FidelityCard : Naylah.Core.Entities.EntityBase
    {
        public FidelityCard()
        {
            Expenses = new List<FidelityExpense>();
        }

        #region Relations

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public FidelityPlan FidelityPlan { get; set; }

        public string FidelityPlanId { get; set; }

        public IList<FidelityExpense> Expenses { get; set; }

        public DataStore DataStore { get; set; }

        public string DataStoreId { get; set; }

        #endregion

        #region Helpers

        public FidelityCardPointInfo PointInfo { get { return new FidelityCardPointInfo(this); } }

        public FidelityCardBenefitInfo BenefitInfo { get { return new FidelityCardBenefitInfo(this); } }

        public decimal TotalExpense { get { return (Expenses.Where(x => x.IsInput).Sum(x => x.Total) - Expenses.Where(x => x.IsOutput).Sum(x => x.Total)); } }

        public string TotalExpensePresentation { get { return TotalExpense.ToString("C"); } }

        public string Color { get { return ColorExtention.GetARandomHexFlatColor(); } }

        public string PointsAndBenefitsInfo
        {
            get
            {
                return "✅ " + PointInfo.HasAchievedForNextBenefitRound + " / " + FidelityPlan.Benefit.NecessaryPoint + " \n🎁 " + BenefitInfo.TotalAchivedRound;
            }
        }

        #endregion
    }

    //public class FidelityCardInfoBase
    //{
    //    protected FidelityCard Card { get; set; }

    //    public FidelityCardInfoBase(FidelityCard _card)
    //    {
    //        Card = _card;
    //    }

    //    public FidelityCardPointInfo PointInfo { get { return new FidelityCardPointInfo(Card); } }

    //    public FidelityCardBenefitInfo BenefitInfo { get { return new FidelityCardBenefitInfo(Card); } }
    //}

    public class FidelityCardPointInfo
    {
        protected FidelityCard Card { get; set; }

        public FidelityCardPointInfo(FidelityCard _card)
        {
            Card = _card;
        }

        public decimal TotalAchived { get { return decimal.Divide(Card.TotalExpense, Card.FidelityPlan.Config.ExpenseForOnePoint); } }

        public decimal TotalAchivedInMoney
        {
            get
            {
                var a = (TotalAchived * Card.FidelityPlan.ValueOnePoint);
                return a;
            }
        }

        public string TotalAchivedInMoneyPresentation { get { return TotalAchivedInMoney.ToString("C"); } }

        public decimal HasAchievedForNextBenefit
        {
            get
            {
                if (TotalAchived < Card.FidelityPlan.Benefit.NecessaryPoint)
                    return TotalAchived;

                return TotalAchived - (Card.BenefitInfo.TotalAchivedRound * Card.FidelityPlan.Benefit.NecessaryPoint);
            }
        }

        public decimal HasAchievedForNextBenefitRound { get { return HasAchievedForNextBenefit.RoundToDown(); } }

        public decimal NeedForNextBenefit { get { return Card.FidelityPlan.Benefit.NecessaryPoint - HasAchievedForNextBenefit; } }

        public decimal NeedForNextBenefitRound { get { return NeedForNextBenefit.RoundToUp(); } }

        public string NeedExpenseForNext
        {
            get
            {
                decimal v;

                if (!AchievedTheFirst)
                    _ = (Card.FidelityPlan.Config.ExpenseForOnePoint - Card.TotalExpense);

                v = Card.FidelityPlan.Config.ExpenseForOnePoint - (Card.FidelityPlan.Config.ExpenseForOnePoint * (HasAchievedForNextBenefit - Math.Truncate(HasAchievedForNextBenefit)));

                return v.ToString("C");
            }
        }

        public string NeedExpenseForNextPresentation { get { return "Gaste " + NeedExpenseForNext + " para ganhar + 1 ponto! " + EmojiExtention.GetARandomEmojiHappy; } }

        public bool AchievedTheFirst { get { return HasAchievedForNextBenefit >= 1; } }

        public string Icons
        {
            get
            {
                var r = "";

                for (int i = 0; i < HasAchievedForNextBenefitRound; i++)
                {
                    //if(i.Equals(0))
                    //    r += "✅"

                    r += "✅ ";
                }

                for (int i = 0; i < NeedForNextBenefitRound; i++)
                {
                    r += "⬜ ";
                }

                return r;
            }
        }
    }

    public class FidelityCardBenefitInfo
    {
        protected FidelityCard Card { get; set; }

        public FidelityCardBenefitInfo(FidelityCard _card)
        {
            Card = _card;
        }

        public decimal TotalAchived { get { return Card.PointInfo.TotalAchived / Card.FidelityPlan.Benefit.NecessaryPoint; } }

        public decimal TotalAchivedRound { get { return TotalAchived.RoundToDown(); } }

        public string NeedExpenseForNext { get { return (Card.PointInfo.NeedForNextBenefit * Card.FidelityPlan.Config.ExpenseForOnePoint).ToString("C"); } }

        public bool AchievedTheFirst { get { return TotalAchived >= 1; } }

        public string Icons
        {
            get
            {
                var r = "";

                for (int i = 0; i < TotalAchivedRound; i++)
                {
                    r += "🎁 ";
                }

                return r;
            }
        }

        public decimal BenefitValue { get { return (Card?.FidelityPlan?.Benefit?.NecessaryPoint * Card?.FidelityPlan?.Config?.ExpenseForOnePoint) ?? 0; } }

        public FidelityCard FromCard { get { return Card; } }

        public List<FidelityCardBenefitAchivedAux> AchiavedList
        {
            get
            {
                var listReturn = new List<FidelityCardBenefitAchivedAux>();

                if (TotalAchivedRound <= 0)
                    return listReturn;

                for (int i = 0; i < TotalAchivedRound; i++)
                {
                    listReturn.Add(new FidelityCardBenefitAchivedAux
                    {
                        Company = Card.FidelityPlan?.DataItem?.Description?.Title,
                        Description = Card.FidelityPlan?.Benefit?.Description,
                        Value = BenefitValue,
                        HappyMsg = StringExtention.GetARandomHappyMessage,
                        Card = Card
                    });
                }

                return listReturn;
            }
        }
    }

    public class FidelityCardBenefitAchivedAux
    {
        public string HappyMsg { get; set; }

        public string Description { get; set; }

        public string Company { get; set; }

        public decimal Value { get; set; }

        public FidelityCard Card { get; set; }
    }
}

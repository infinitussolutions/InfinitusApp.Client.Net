using Naylah.Core.Entities;
using System;
using System.Collections.Generic;

namespace InfinitusApp.Core.Data.DataModels
{
    public class PaymentCondition : EntityBase
    {
        public PaymentCondition()
        {
            Installment = new InstallmentCondition { DaysInterval = 30 };
            ExtraValue = new PaymentConditionPrice();
            FinancialRequests = new List<FinancialRequest>();
            Type = PaymentConditionType.InCash;
            PaymentMethod = PaymentMethodType.Cash;
            Term = new TermCondition();
        }

        public string Title { get; set; }

        public InstallmentCondition Installment { get; set; }

        public TermCondition Term { get; set; }

        public PaymentConditionType Type { get; set; }

        public PaymentMethodType PaymentMethod { get; set; }

        public PaymentConditionPrice ExtraValue { get; set; }

        public PaymentConditionTarget Target { get; set; }

        public string ExternalReference { get; set; }

        #region Relations

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        public virtual IList<FinancialRequest> FinancialRequests { get; set; }

        #endregion

        #region Helps

        public string TypePresentation 
        {
            get
            {
                switch (Type)
                {
                    case PaymentConditionType.InCash: return "À Vista";
                    case PaymentConditionType.Installments: return "Parcelado";
                    case PaymentConditionType.Term: return "A Prazo";
                    default: return "Indefinido";
                }
            }
        }

        public string PaymentMethodPresentation 
        {
            get
            {
                switch (PaymentMethod)
                {
                    case PaymentMethodType.BankSlip: return "Boleto";
                    case PaymentMethodType.Cash: return "Dinheiro";
                    case PaymentMethodType.CreditCard: return "Cartão de Crédito";
                    case PaymentMethodType.DebitCard: return "Cartão de Débito";
                    case PaymentMethodType.FoodVoucher: return "Vale Refeição";
                    case PaymentMethodType.MealTicket: return "Vale Alimentação";
                    default: return string.Empty;
                }
            }
        }

        public bool HasId 
        {
            get
            {
                return !string.IsNullOrEmpty(Id);
            }
        }

        public string TitlePresentation 
        {
            get
            {
                if (ExtraValue.DiscountInPercent > 0)
                    return string.Format("{0} ({1}% de desconto)", Title, ExtraValue.DiscountInPercent);

                return Title;
            }
        }

        public bool IsInCash
        {
            get
            {
                return Type == PaymentConditionType.InCash;
            }
        }

        public bool IsInstallment 
        {
            get
            {
                return Type == PaymentConditionType.Installments;
            }
        }

        public bool IsTerm
        {
            get
            {
                return Type == PaymentConditionType.Term;
            }
        }

        #endregion

        public enum PaymentConditionType
        {
            Unknow,
            InCash,
            Installments,
            Term
        }

    }

    public enum PaymentMethodType
    {
        Unknow,
        Cash,
        CreditCard,
        DebitCard,
        BankSlip,
        MealTicket,
        FoodVoucher
    }

    public enum PaymentConditionTarget
    {
        All,
        Salesman,
        Customer
    }

    public class InstallmentCondition
    {
        public int Quantity { get; set; }

        public int DaysInterval { get; set; }

        public int DaysForFirstInstallment { get; set; }
    }

    public class TermCondition
    {
        public int QuantityDaysForPayment { get; set; }

        public PaymentDay DayForPayment { get; set; }

        public bool HasPaymentDay 
        {
            get
            {
                return DayForPayment != PaymentDay.None;
            }
        }

        public DateTime DueDate
        {
            get
            {
                if (DayForPayment == PaymentDay.None)
                    return DateTime.Now.AddDays(QuantityDaysForPayment);

                var day = (int)DayForPayment;

                if (day > DateTime.Now.Day)
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);

                var nextMonth = DateTime.Now.AddMonths(1);

                return new DateTime(nextMonth.Year, nextMonth.Month, day);

            }
        }
    }

    public enum PaymentDay
    {
        None = -1,
        Day01 = 1,
        Day05 = 5,
        Day10 = 10,
        Day15 = 15,
        Day20 = 20,
        Day25 = 25
    }

    public class PaymentConditionPrice
    {
        public decimal DiscountInPercent { get; set; }

        public decimal AdditionalInPercent { get; set; }
    }
}
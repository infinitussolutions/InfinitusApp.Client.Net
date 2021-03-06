﻿using Naylah.Core.Entities;
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
            Relations = new List<PaymentConditionRelation>();
            Icon = new FontIcon();
        }

        public string Title { get; set; }

        public InstallmentCondition Installment { get; set; }

        public TermCondition Term { get; set; }

        public PaymentConditionType Type { get; set; }

        public PaymentMethodType PaymentMethod { get; set; }

        public PaymentConditionPrice ExtraValue { get; set; }

        public PaymentConditionTarget Target { get; set; }

        public string ExternalReference { get; set; }

        public bool ExternalProcessing { get; set; }

        public FontIcon Icon { get; set; }

        #region Relations

        public DataStore DataStore { get; set; }

        public string DataStoreId { get; set; }

        public IList<FinancialRequest> FinancialRequests { get; set; }

        public IList<PaymentConditionRelation> Relations { get; set; }

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
                    case PaymentMethodType.FoodVoucher: return "Vale Alimentação";
                    case PaymentMethodType.MealTicket: return "Vale Refeição";
                    case PaymentMethodType.Pix: return "Pix";
                    default: return PaymentMethod.ToString();
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
                if (ExtraValue.Total > 0)
                    return string.Format("{0} ({1}% de desconto)", Title, ExtraValue.DiscountInPercent);

                if (ExtraValue.Total < 0)
                    return string.Format("{0} ({1}% de juros)", Title, ExtraValue.AdditionalInPercent);

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
        FoodVoucher,
        Pix
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
                try
                {
                    if (DayForPayment == PaymentDay.None)
                        return QuantityDaysForPayment > 0 ? DateTime.Now.AddDays(QuantityDaysForPayment) : DateTime.Now;

                    var day = (int)DayForPayment;

                    if (day > DateTime.Now.Day)
                        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);

                    var nextMonth = DateTime.Now.AddMonths(1);

                    return new DateTime(nextMonth.Year, nextMonth.Month, day);
                }

                catch (Exception)
                {
                    return DateTime.Now;
                }
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

        public decimal Total 
        {
            get
            {
                return DiscountInPercent - AdditionalInPercent;
            }
        }
    }

    public class PaymentConditionRelation : EntityBase
    {
        public virtual PaymentCondition PaymentCondition { get; set; }
        public virtual string PaymentConditionId { get; set; }
        public virtual DataItem DataItem { get; set; }
        public virtual string DataItemId { get; set; }
    }
}
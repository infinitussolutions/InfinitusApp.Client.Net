using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Signature
{
    public enum SignaturePlanRecurrenceChargeDays
    {
        Monthy,
        Semester,
        Yearly
    }

    public class SignaturePlan : Naylah.Core.Entities.EntityBase
    {
        public SignaturePlan()
        {
            Config = new SignaturePlanConfig();
            SignaturePlanApplicationUsers = new List<SignaturePlanApplicationUser>();
            Consumptions = new List<SignaturePlanConsumption>();
            Actions = new List<SignaturePlanAction>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public SignaturePlanConfig Config { get; set; }

        public bool Active { get; set; } = true;

        /// <summary>
        /// Used to show where is upgrade action
        /// </summary>
        [JsonIgnore]
        public bool ShowToUpgrade { get; set; }

        #region Relations

        public string DataStoreId { get; set; }

        public IList<SignaturePlanApplicationUser> SignaturePlanApplicationUsers { get; set; }

        public IList<SignaturePlanConsumption> Consumptions { get; set; }

        public IList<SignaturePlanAction> Actions { get; set; }

        #endregion

        #region Help

        [JsonIgnore]
        public string AmountPresentation { get { return Amount.ToString("C"); } }

        #endregion
    }

    public class SignaturePlanConfig
    {
        public SignaturePlanConfig()
        {
            Requirements = new SignaturePlanRequirements();
        }
        public int DaysToStartFirstCharge { get; set; }

        public SignaturePlanRecurrenceChargeDays RecurrenceChargeDaysType { get; set; } = SignaturePlanRecurrenceChargeDays.Monthy;

        /// <summary>
        /// Default is 5
        /// </summary>
        public int DaysWithoutPaymentToBlock { get; set; } = 5;

        public SignaturePlanRequirements Requirements { get; set; }

        #region Help

        public int RecurrenceChargeDaysFromType
        {
            get
            {
                switch (RecurrenceChargeDaysType)
                {
                    case SignaturePlanRecurrenceChargeDays.Semester:
                        return 180;

                    case SignaturePlanRecurrenceChargeDays.Yearly:
                        return 360;

                    case SignaturePlanRecurrenceChargeDays.Monthy:
                    default:
                        return 30;
                }
            }
        }

        public string RecurrencyPresentation
        {
            get
            {
                switch (RecurrenceChargeDaysType)
                {
                    case SignaturePlanRecurrenceChargeDays.Semester:
                        return "Semestral";
                    case SignaturePlanRecurrenceChargeDays.Yearly:
                        return "Anual";
                    case SignaturePlanRecurrenceChargeDays.Monthy:
                    default:
                        return "Mensal";
                }
            }
        }

        public string DaysWithoutPaymentToBlockPresentation
        {
            get
            {
                return "Dias sem pagamento p/ bloquear assinatura: " + DaysWithoutPaymentToBlock;
            }
        }

        public string DaysToStartFirstChargePresentation
        {
            get
            {
                var date = DateTime.UtcNow.AddDays(DaysToStartFirstCharge).Date;

                var msg = "Começa a pagar a partir de: ";

                if (DaysToStartFirstCharge.Equals(0))
                    msg += "Mesmo Dia ";

                else
                    msg += DaysToStartFirstCharge + " dias ";

                msg += "(" + date.ToString("dd/MM") + ")";

                return msg;
            }
        }

        #endregion
    }

    public class SignaturePlanConsumption : EntityBase
    {
        public string Description { get; set; }

        public double Quantity { get; set; }

        public decimal Total { get; set; }

        public string Observation { get; set; }

        #region Relations

        public SignaturePlan SignaturePlan { get; set; }
        public string SignaturePlanId { get; set; }

        #endregion
    }

    public class SignaturePlanRequirements
    {
        public bool SubAccount { get; set; }
    }

    public class SignaturePlanAction : EntityBase
    {
        public string SolutionId { get; set; }

        #region Relations

        public SignaturePlan SignaturePlan { get; set; }
        public string SignaturePlanId { get; set; }

        #endregion
    }
}

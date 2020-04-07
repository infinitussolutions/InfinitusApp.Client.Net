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
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public SignaturePlanConfig Config { get; set; }

        public bool Active { get; set; } = true;

        #region Relations

        public virtual string DataStoreId { get; set; }

        public virtual IList<SignaturePlanApplicationUser> SignaturePlanApplicationUsers { get; set; }

        #endregion

        #region Help

        public string AmountPresentation { get { return Amount.ToString("C"); } }

        #endregion


    }

    public class SignaturePlanConfig
    {
        public int DaysToStartFirstCharge { get; set; }

        public SignaturePlanRecurrenceChargeDays RecurrenceChargeDaysType { get; set; } = SignaturePlanRecurrenceChargeDays.Monthy;

        /// <summary>
        /// Default is 5
        /// </summary>
        public int DaysWithoutPaymentToBlock { get; set; } = 5;

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
}

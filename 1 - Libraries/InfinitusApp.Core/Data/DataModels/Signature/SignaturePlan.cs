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
            SignatureStartDateConfig = new SignatureStartDateConfig();
            SignaturePlanApplicationUsers = new List<SignaturePlanApplicationUser>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public SignaturePlanRecurrenceChargeDays RecurrenceChargeDaysType { get; set; } = SignaturePlanRecurrenceChargeDays.Monthy;

        /// <summary>
        /// Default is 5
        /// </summary>
        public int DaysWithoutPaymentToBlock { get; set; } = 5;

        /// <summary>
        /// Set to sample, 3 mounths free so set 3 to mounth
        /// </summary>
        public SignatureStartDateConfig SignatureStartDateConfig { get; set; }

        #region Help

        public int RecurrencyDaysToCharge
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

        #endregion

        #region Relations

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        public virtual IList<SignaturePlanApplicationUser> SignaturePlanApplicationUsers { get; set; }

        #endregion
    }

    public class SignatureStartDateConfig
    {
        public int Mounths { get; set; }

        public int Days { get; set; }
    }
}

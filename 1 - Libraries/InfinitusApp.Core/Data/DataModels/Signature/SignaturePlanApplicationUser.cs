using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Signature
{
    public class SignaturePlanApplicationUser : Naylah.Core.Entities.EntityBase
    {
        public SignaturePlanApplicationUser()
        {
            PaymentHistoryList = new List<SignaturePlanPaymentHistory>();
        }

        #region Relations

        public virtual SignaturePlan SignaturePlan { get; set; }

        public virtual string SignaturePlanId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual string ApplicationUserId { get; set; }

        public virtual CreditCardInfo CreditCardInfo { get; set; }

        public virtual string CreditCardInfoId { get; set; }

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        public virtual IList<SignaturePlanPaymentHistory> PaymentHistoryList { get; set; }

        #endregion

        #region Help

        public DateTimeOffset NextCharge { get; set; }

        public DateTimeOffset? LastChargePayment { get; set; }

        public int DaysWithoutPayment { get; set; }

        public string PlanStatusMsg { get; set; }

        public bool? IsBlockPlan { get; set; }

        #endregion
    }
}

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


        public DateTimeOffset NextCharge
        {
            get
            {
                if (!LastChargePayment.HasValue && string.IsNullOrEmpty(SignaturePlan?.Id))
                    return DateTimeOffset.MinValue;

                return LastChargePayment.HasValue ? LastChargePayment.Value.AddDays(SignaturePlan.RecurrencyDaysToCharge) : DateTimeOffset.UtcNow.AddMonths(SignaturePlan.SignatureStartDateConfig.Mounths).AddDays(SignaturePlan.SignatureStartDateConfig.Days).Date;
            }
        }

        public DateTimeOffset? LastChargePayment
        {
            get
            {
                if (PaymentHistoryList == null || PaymentHistoryList.Count.Equals(0))
                    return null;

                return PaymentHistoryList?.OrderByDescending(x => x.CreatedAt).Select(x => x.CreatedAt)?.FirstOrDefault().Value.Date;
            }
        }

        public int DaysWithoutPayment
        {
            get
            {
                return (int)((DateTimeOffset.Now.Date - NextCharge.Date).TotalDays);
            }
        }

        public string PlanStatusMsg
        {
            get
            {
                if (!IsBlockPlan)
                {
                    if (DaysWithoutPayment > 0)
                        return "Plano ativo, porém a " + DaysWithoutPayment + " dias sem pagamento, ao atingir " + SignaturePlan.DaysWithoutPaymentToBlock + " dias o mesmo será bloqueado";

                    return "Plano ativo! Próxima pagamento em " + NextCharge.ToString("dd/MM/yyyy dddd");
                }

                else
                {
                    if (!LastChargePayment.HasValue)
                        return "Primeiro pagamento ainda não encontrado";

                    if (DaysWithoutPayment >= SignaturePlan.DaysWithoutPaymentToBlock)
                        return "Plano bloqueado por falta de pagamento";
                }

                return "";
            }
        }

        public bool IsBlockPlan
        {
            get
            {
                if (NextCharge.Date > DateTimeOffset.Now.Date)
                    return false;

                else
                {
                    if (!LastChargePayment.HasValue)
                        return true;
                }

                return DaysWithoutPayment >= SignaturePlan.DaysWithoutPaymentToBlock;
            }
        }

        #endregion
    }
}

using Newtonsoft.Json;
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

        public virtual DataItem DataItem { get; set; }

        public virtual string DataItemId { get; set; }

        public virtual string DataStoreId { get; set; }

        public virtual IList<SignaturePlanPaymentHistory> PaymentHistoryList { get; set; }

        #endregion

        #region Help

        [JsonIgnore]
        public DateTimeOffset NextCharge
        {
            get
            {
                try
                {
                    if (!LastChargePayment.HasValue && string.IsNullOrEmpty(SignaturePlan?.Id))
                        return DateTimeOffset.MinValue;

                    return LastChargePayment.HasValue ? LastChargePayment.Value.AddDays(SignaturePlan.Config.RecurrenceChargeDaysFromType) : DateTimeOffset.UtcNow.AddDays(SignaturePlan.Config.DaysToStartFirstCharge).Date;
                }
                catch (Exception)
                {
                    return DateTime.MinValue;
                }
            }
        }

        [JsonIgnore]
        public string NextChargePresentation => NextCharge.ToString("dd/MMMM");

        [JsonIgnore]
        public DateTimeOffset? LastChargePayment
        {
            get
            {
                if (PaymentHistoryList == null || PaymentHistoryList.Count.Equals(0))
                    return null;

                return PaymentHistoryList?.OrderByDescending(x => x.CreatedAt).Select(x => x.CreatedAt)?.FirstOrDefault().Value.LocalDateTime.Date;
            }
        }

        [JsonIgnore]
        public int DaysWithoutPayment
        {
            get
            {
                try
                {
                    return (int)((DateTimeOffset.Now.Date - NextCharge.Date).TotalDays);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        [JsonIgnore]
        public string PlanStatusMsg
        {
            get
            {
                try
                {
                    if (!IsBlockPlan.HasValue)
                        return "Not found info";

                    if (!IsBlockPlan.Value)
                    {
                        if (DaysWithoutPayment > 0)
                            return "Ativo! porém a " + DaysWithoutPayment + " dias sem pagamento, ao atingir " + SignaturePlan?.Config?.DaysWithoutPaymentToBlock + " dias o mesmo será bloqueado";

                        return "Ativo! Próxima pagamento em " + NextCharge.ToString("dd/MM");
                    }

                    else
                    {
                        if (!LastChargePayment.HasValue)
                            return "Primeiro pagamento não encontrado";

                        if (DaysWithoutPayment >= SignaturePlan?.Config?.DaysWithoutPaymentToBlock)
                            return "Bloqueado por falta de pagamento";
                    }

                    return "";
                }
                catch (Exception)
                {
                    return "Not found info";
                }
            }
        }

        [JsonIgnore]
        public bool? IsBlockPlan
        {
            get
            {
                try
                {
                    if (NextCharge.Date > DateTimeOffset.Now.Date)
                        return false;

                    else
                    {
                        if (!LastChargePayment.HasValue)
                            return true;
                    }

                    return DaysWithoutPayment >= SignaturePlan.Config.DaysWithoutPaymentToBlock;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        //public DateTimeOffset NextCharge { get; set; }

        //public DateTimeOffset? LastChargePayment { get; set; }

        //public int DaysWithoutPayment { get; set; }

        //public string PlanStatusMsg { get; set; }

        //public bool? IsBlockPlan { get; set; }

        #endregion
    }
}

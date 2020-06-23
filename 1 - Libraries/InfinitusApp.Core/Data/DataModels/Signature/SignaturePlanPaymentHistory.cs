using Ebanx.net.Parameters.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Signature
{
    public class SignaturePlanPaymentHistory : Naylah.Core.Entities.EntityBase
    {
        public SignaturePlanPaymentHistory()
        {
            SignaturePlanApplicationUser = new SignaturePlanApplicationUser();
        }

        public DateTimeOffset NextPaymentDate { get; set; }

        public ExternalReferenceType ExternalReferenceType { get; set; }

        public string ExternalReferenceId { get; set; }

        public PaymentResponse ExternalReferenceModel { get; set; }

        #region Relations

        public virtual string SignaturePlanApplicationUserId { get; set; }

        public virtual SignaturePlanApplicationUser SignaturePlanApplicationUser { get; set; }

        public virtual string DataStoreId { get; set; }

        #endregion

        #region Help

        public decimal ExternalReferenceAmount { get { return Convert.ToDecimal(((PaymentResponse)ExternalReferenceModel)?.AmountBr); } }

        public string ExternalReferenceAmountPresentation { get { return ExternalReferenceAmount.ToString("C"); } }

        public bool? ExternalReferenceIsPaid { get { return ((PaymentResponse)ExternalReferenceModel)?.IsPaid ?? null; } }

        public DateTime? ExternalReferenceConfirmPaymentDate { get { return Convert.ToDateTime(((PaymentResponse)ExternalReferenceModel)?.ConfirmDate); } }

        public string PaymentType { get { return ((PaymentResponse)ExternalReferenceModel)?.PaymentTypeCode; } }

        #endregion
    }

    public class SignaturePlanChargeTodayExtention
    {
        public string ApplicationUserName { get; set; }

        public string SignaturePlanName { get; set; }

        public string SignaturePlanApplicationUserId { get; set; }

        public string DataStoreId { get; set; }

        public DateTimeOffset NextCharge { get; set; }

        public decimal Amount { get; set; }
    }
}

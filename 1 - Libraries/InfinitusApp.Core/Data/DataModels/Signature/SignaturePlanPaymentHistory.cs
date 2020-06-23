using Ebanx.net.Parameters.Responses;
using Newtonsoft.Json;
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

        [JsonIgnore]
        public decimal ExternalReferenceAmount
        {
            get
            {
                switch (ExternalReferenceType)
                {
                    case ExternalReferenceType.Undefined:
                        throw new ArgumentException(nameof(ExternalReferenceType.Undefined) + " is not a valid type");

                    case ExternalReferenceType.Iugu:
                        throw new ArgumentException(nameof(ExternalReferenceType.Iugu) + " is not a valid type");

                    case ExternalReferenceType.Ebanx:
                    default:
                        var m = (PaymentResponse)ExternalReferenceModel;
                        return m == null ? 0 : decimal.Parse(m.AmountBr.ToString());

                }
            }
        }

        [JsonIgnore]
        public string ExternalReferenceAmountPresentation { get { return ExternalReferenceAmount.ToString("C"); } }

        [JsonIgnore]
        public bool? ExternalReferenceIsPaid
        {
            get
            {
                switch (ExternalReferenceType)
                {
                    case ExternalReferenceType.Undefined:
                        throw new ArgumentException(nameof(ExternalReferenceType.Undefined) + " is not a valid type");

                    case ExternalReferenceType.Iugu:
                        throw new ArgumentException(nameof(ExternalReferenceType.Iugu) + " is not a valid type");

                    case ExternalReferenceType.Ebanx:
                    default:
                        return ((PaymentResponse)ExternalReferenceModel)?.IsPaid ?? null;
                }
            }
        }

        [JsonIgnore]
        public DateTime? ExternalReferenceConfirmPaymentDate
        {
            get
            {
                if (!ExternalReferenceIsPaid.HasValue)
                    return null;

                switch (ExternalReferenceType)
                {
                    case ExternalReferenceType.Undefined:
                        throw new ArgumentException(nameof(ExternalReferenceType.Undefined) + " is not a valid type");

                    case ExternalReferenceType.Iugu:
                        throw new ArgumentException(nameof(ExternalReferenceType.Iugu) + " is not a valid type");

                    case ExternalReferenceType.Ebanx:
                    default:
                        return Convert.ToDateTime(((PaymentResponse)ExternalReferenceModel)?.ConfirmDate);
                }
            }
        }

        [JsonIgnore]
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

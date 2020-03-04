using Ebanx.net.Parameters.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.Signature
{
    public class SignaturePlanPaymentHistory : Naylah.Core.Entities.EntityBase
    {
        public DateTimeOffset NextPaymentDate { get; set; }

        public ExternalReferenceType ExternalReferenceType { get; set; }

        public string ExternalReferenceId { get; set; }

        /// <summary>
        /// Ebanx type is PaymentResponse
        /// </summary>
        public object ExternalReferenceModel { get; set; }

        #region Relations

        public virtual string SignaturePlanApplicationUserId { get; set; }

        public virtual SignaturePlanApplicationUser SignaturePlanApplicationUser { get; set; }

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        #endregion

        #region Help

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
                        return decimal.Parse(m.AmountBr.ToString());
                }
            }
        }

        public string ExternalReferenceAmountPresentation { get { return ExternalReferenceAmount.ToString("C"); } }

        public bool ExternalReferenceIsPaid
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
                        return m.IsPaid;
                }
            }
        }

        public DateTime? ExternalReferenceConfirmPaymentDate
        {
            get
            {
                if (!ExternalReferenceIsPaid)
                    return null;

                switch (ExternalReferenceType)
                {
                    case ExternalReferenceType.Undefined:
                        throw new ArgumentException(nameof(ExternalReferenceType.Undefined) + " is not a valid type");

                    case ExternalReferenceType.Iugu:
                        throw new ArgumentException(nameof(ExternalReferenceType.Iugu) + " is not a valid type");

                    case ExternalReferenceType.Ebanx:
                    default:
                        var m = (PaymentResponse)ExternalReferenceModel;
                        return DateTime.Parse(m.ConfirmDate);
                }
            }
        }

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

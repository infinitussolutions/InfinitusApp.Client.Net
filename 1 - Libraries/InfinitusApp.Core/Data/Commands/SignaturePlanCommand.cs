using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Data.DataModels.Signature;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class SignaturePlanCommand
    {
    }

    public class SignatureBaseCommand
    {
        public SignatureBaseCommand()
        {
            Config = new SignaturePlanConfig();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public SignaturePlanConfig Config { get; set; }

    }

    public class CreateSignaturePlanCommand : SignatureBaseCommand
    {
        public string DataStoreId { get; set; }

        public string MsgIsNotValid
        {
            get
            {
                var msg = "";

                //if (string.IsNullOrEmpty(DataStoreId))
                //    msg += nameof(DataStoreId) + " is not valid\n";

                if (string.IsNullOrEmpty(Title))
                    msg += nameof(Title) + " is not valid\n";

                if (string.IsNullOrEmpty(Description))
                    msg += nameof(Description) + " is not valid\n";

                if (Amount.Equals(0))
                    msg += nameof(Amount) + " is not valid\n";

                return msg;
            }
        }
    }

    public class UpdateSignaturePlanCommand : SignatureBaseCommand
    {
        public string Id { get; set; }

        public bool Active { get; set; } = true;

        public string MsgIsNotValid
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Id))
                    msg += nameof(Id) + " is not valid\n";

                return msg;
            }
        }
    }


    public class SignaturePlanApplicationUserBaseCommand
    {
        public string SignaturePlanId { get; set; }

        //public string ApplicationUserId { get; set; }

        public string CreditCardInfoId { get; set; }
    }

    public class CreateSignaturePlanApplicationUserCommand : SignaturePlanApplicationUserBaseCommand
    {
        public string DataStoreId { get; set; }

        public string DataItemId { get; set; }

        public string AppUserId { get; set; }

        public string MsgIsNotValid
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(CreditCardInfoId))
                    msg += nameof(CreditCardInfoId) + " is not valid\n";

                if (string.IsNullOrEmpty(SignaturePlanId))
                    msg += nameof(SignaturePlanId) + " is not valid\n";

                //if (string.IsNullOrEmpty(ApplicationUserId))
                //    msg += nameof(ApplicationUserId) + " is not valid\n";

                return msg;
            }
        }
    }

    public class UpdateSignaturePlanApplicationUserCommand : SignaturePlanApplicationUserBaseCommand
    {
        public string Id { get; set; }
    }

    public class CreateSignaturePlanPaymentHistoryCommand
    {
        /// <summary>
        /// Ebanx PaymentResponse
        /// </summary>
        //public DirectResponse DirectResponse { get; set; }

        public ExternalReferenceType ExternalReferenceType { get; set; } = ExternalReferenceType.Ebanx;

        //public float AmountTotal { get; set; }

        //public string MerchantPaymentCode { get; set; }

        public string SignaturePlanApplicationUserId { get; set; }

        //public ExternalReferenceType ExternalReferenceType { get { return ExternalReferenceType.Ebanx; } }

        //public string ExternalReferenceId { get { return DirectResponse.Payment?.Hash; } }

        //public PaymentResponse ExternalReferenceModel { get { return DirectResponse.Payment; } }

        //public CreditCardInfo CreditCard { get; set; }

        public string DataStoreId { get; set; }

        public string MsgIsNotValid
        {
            get
            {
                var msg = "";

                //if (string.IsNullOrEmpty(MerchantPaymentCode))
                //    msg += nameof(MerchantPaymentCode) + " is not valid\n";

                //if (!(AmountTotal > 0))
                //    msg += nameof(AmountTotal) + " is not valid\n";

                if (string.IsNullOrEmpty(SignaturePlanApplicationUserId))
                    msg += nameof(SignaturePlanApplicationUserId) + " is not valid\n";

                return msg;
            }
        }
    }

    #region Consumption

    public class SignaturePlanConsumptionCommand
    {
        public string Description { get; set; }

        public double Quantity { get; set; }

        public decimal Total { get; set; }

        public string Observation { get; set; }
    }

    public class CreateSignaturePlanConsumptionCommand : SignaturePlanConsumptionCommand
    {
        public string SignaturePlanId { get; set; }
    }

    public class UpdateSignaturePlanConsumptionCommand : SignaturePlanConsumptionCommand
    {
        public string Id { get; set; }
    }

    #endregion

    public class SignaturePlanActionCommand
    {

    }

    public class CreateSignaturePlanActionCommand : SignaturePlanActionCommand
    {
        public string SignaturePlanId { get; set; }

        public string SolutionId { get; set; }
    }
}

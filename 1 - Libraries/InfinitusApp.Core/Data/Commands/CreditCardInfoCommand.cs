using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class CreditCardInfoCommand
    {
    }

    public class CreateCreditCardInfoCommand
    {
        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public string CardCvv { get; set; }

        /// <summary>
        /// Format mm/yyyy
        /// </summary>
        public string DueDate { get; set; }

        public ExternalReferenceType ExternalReferenceType { get; set; } = ExternalReferenceType.Ebanx;

        //public string ApplicationUserId { get; set; }

        //public string MaskedNumber { get; set; }

        //public string Token { get; set; }

        //public string Type { get; set; }

        public string MsgInvalid
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(CardNumber))
                    msg += nameof(CardNumber) + " is invalid";

                if (string.IsNullOrEmpty(CardName))
                    msg += nameof(CardName) + " is invalid";

                if (string.IsNullOrEmpty(CardCvv))
                    msg += nameof(CardCvv) + " is invalid";

                if (string.IsNullOrEmpty(DueDate))
                    msg += nameof(DueDate) + " is invalid";

                if (!DateTime.TryParse(DueDate, out DateTime result))
                    msg += nameof(DueDate) + " is not a valid date";

                return msg;
            }
        }
    }

    public class SetAProblemCreditCardInfoCommand
    {
        public string CreditCardInfoId { get; set; }

        public string ProblemDescription { get; set; }

        public string MsgInvalid
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(CreditCardInfoId))
                    msg += nameof(CreditCardInfoId) + " is invalid";

                if (string.IsNullOrEmpty(ProblemDescription))
                    msg += nameof(ProblemDescription) + " is invalid";

                return msg;
            }
        }
    }

    public class ChangeCreditCardDefaultCommand
    {
        public string FromId { get; set; }

        public string ToId { get; set; }
    }
}

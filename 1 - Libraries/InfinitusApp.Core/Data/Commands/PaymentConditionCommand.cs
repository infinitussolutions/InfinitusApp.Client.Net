using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.PaymentCondition;

namespace InfinitusApp.Core.Data.Commands
{
    public class PaymentConditionCommand
    {
        public string Title { get; set; }

        public PaymentConditionPrice ExtraValue { get; set; }

        public PaymentConditionTarget Target { get; set; }
    }

    public class CreatePaymentConditionCommand : PaymentConditionCommand
    {
        public string DataStoreId { get; set; }

        public InstallmentCondition Installment { get; set; }

        public TermCondition Term { get; set; }

        public PaymentConditionType Type { get; set; }

        public PaymentMethodType PaymentMethod { get; set; }

        #region Helps

        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(ErrorMsg);

            }
        }

        public string ErrorMsg
        {
            get
            {
                try
                {
                    var errorMsg = string.Empty;

                    switch (PaymentMethod)
                    {
                        case PaymentMethodType.BankSlip:

                            switch (Type)
                            {
                                case PaymentConditionType.InCash:
                                    errorMsg += "Boleto não pode ser usado em pagamentos á vista\n";
                                    break;

                                case PaymentConditionType.Term:

                                    if (Term.QuantityDaysForPayment > 30)
                                        errorMsg += "Boletos só podem ser gerados para no máximo 30 dias\n";

                                    break;
                            }

                            break;

                        case PaymentMethodType.Cash:

                            if (Type != PaymentConditionType.InCash)
                                errorMsg += "Dinheiro só pode ser usado em pagamentos á vista\n";

                            break;

                        case PaymentMethodType.CreditCard:

                            switch (Type)
                            {
                                case PaymentConditionType.InCash:
                                    errorMsg += "Cartão de crédito não pode ser usado em pagamentos á vista\n";
                                    break;
                            }

                            break;

                        case PaymentMethodType.DebitCard:

                            if (Type != PaymentConditionType.InCash)
                                errorMsg += "Cartão de débito só pode ser usado em pagamentos á vista\n";

                            break;

                        case PaymentMethodType.FoodVoucher:

                            if (Type != PaymentConditionType.InCash)
                                errorMsg += "Vale alimentação só pode ser usado em pagamentos á vista\n";

                            break;

                        case PaymentMethodType.MealTicket:

                            if (Type != PaymentConditionType.InCash)
                                errorMsg += "Vale refeição só pode ser usado em pagamentos á vista\n";

                            break;
                    }

                    return errorMsg;
                }

                catch(Exception e)
                {
                    return e.InnerException.Message;
                }
            }
        }

        #endregion
    }

    public class UpdatePaymentConditionCommand : PaymentConditionCommand
    {
        public string Id { get; set; }
    }
}

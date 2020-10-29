using InfinitusApp.Core.Data.DataModels.External.Iugu;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu
{
    public class InvoiceCommand
    {
        public InvoiceCommand()
        {
            DataItemIds = new List<string>();
        }

        public string DataStoreId { get; set; }

        public string Email { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public Item[] Items { get; set; }

        public decimal Discount { get; set; }

        public bool IgnoreSendEmail { get; set; }

        //public CustomVariables[] CustomVariables { get; set; }

        public string FinancialRequestId { get; set; }

        public IList<string> DataItemIds { get; set; }

       // public int? DiscountInCents { get; set; }

    }

    public class CreateWithCreditCardCommand : InvoiceCommand
    {
        public string PaymentMethodId { get; set; }
    }

    public class CreateWithBankSlipCommand : InvoiceCommand
    {
        public PayerModel PayerCustomer { get; set; }
    }

    public class CreateWithPixCommand : InvoiceCommand
    {

    }

    public class IuguInvoiceCommand
    {
        public CreateWithCreditCardCommand CreditCard { get; set; }
        public CreateWithBankSlipCommand BankSlip { get; set; }
        public CreateWithPixCommand Pix { get; set; }
    }

}

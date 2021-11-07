using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Custom.DrPeanut
{
    public class DrPeanutCommand
    {
        [JsonProperty("token")]
        public string Token { get; }
    }

    public class DrPeanutFinancialRequestCommand : DrPeanutCommand
    {
        [JsonProperty("numeroPedidoItSofitn")]
        public string FinancialRequestId { get; set; }

        [JsonProperty("totalPedido")]
        public decimal TotalRequest { get; set; }

        [JsonProperty("condicaoPgto")]
        public string PaymentConditionId { get; set; }

        [JsonProperty("cpfCnpj ")]
        public string CustomerDocumentNumber { get; set; }

    }

    public class DrPeanutReturnFinancialRequest
    {
        [JsonProperty("numeroPedidoItSofitn")]
        public string FinancialRequestId { get; set; }

        [JsonProperty("valorDesconto")]
        public decimal TotalDiscount { get; set; }

        [JsonProperty("isCondicaoValida")]
        public bool ValidPaymentCondition { get; set; }

        [JsonProperty("msgRetorno")]
        public string MsgError { get; set; }
    }

    public class DrPeanutCustomerCommand : DrPeanutCommand
    {

    }

    public class DrPeanutCreateFinancialRequestCommand : DrPeanutCommand
    {
        [JsonProperty("numeroPedido")]
        public string FinancialRequestId { get; set; }
    }

    public class DrPeanutGetDiscountCommand
    {
        [JsonProperty("customerTypeid")]
        public string CustomerTypeId { get; set; }

        [JsonProperty("identityDocument")]
        public string IdentityDocument { get; set; }

        [JsonProperty("PaymentCondition")]
        public string PaymentConditionId { get; set; }
    }

    public class DrPeanutGetDiscountResponse
    {
        [JsonProperty("customerTypeid")]
        public string CustomerTypeId { get; set; }

        [JsonProperty("value_start")]
        public decimal DiscountStart { get; set; }

        [JsonProperty("value_end")]
        public decimal DiscountEnd { get; set; }

        [JsonProperty("Discount_text")]
        public string Description { get; set; }

        [JsonProperty("discountInPercent")]
        public decimal DiscountPercent { get; set; }

        [JsonProperty("additionalInPercent")]
        public decimal AdditionalDiscountPercent { get; set; }

        [JsonProperty("shipping_obs")]
        public string ShippingObservation { get; set; }

        public string DiscountPresentation => string.Format("{0} - {1}%", Description, TotalDiscount);

        public decimal TotalDiscount => DiscountPercent + AdditionalDiscountPercent;
    }
}

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

        [JsonProperty("totalRequest")]
        public double TotalRequest { get; set; }
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

        public string DiscountPresentation => string.Format("{0} - {1}%", Description, DiscountPercent);

        public decimal TotalDiscount => DiscountPercent + AdditionalDiscountPercent;
    }

    public class DrPeanutGetICSMRequestCommand
    {
        /// <summary>
        /// estadoOrigem
        /// </summary>
        [JsonProperty("estadoOrigem")]
        public string State { get; set; }
    }

    public class DrPeanutGetICSMResponseCommand
    {
        /// <summary>
        /// icmsSTId
        /// </summary>
        [JsonProperty("icmsSTId")]
        public string Id { get; set; }

        /// <summary>
        /// estadoOrigem
        /// </summary>
        [JsonProperty("estadoOrigem")]
        public string State { get; set; }

        /// <summary>
        /// faixaPercentual
        /// </summary>
        [JsonProperty("faixaPercentual")]
        public decimal Percent { get; set; }
    }

    public class DrPeanutRequestsPendingApprovalCommand
    {
        [JsonProperty("documentIdentifier")]
        public string IdentityDocument { get; set; }
    }

    public class DrPeanutRequestsPendingApprovalResponseCommand
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }
        [JsonProperty("orderExpeditionDate")]
        public DateTimeOffset OrderExpeditionDate { get; set; }
        [JsonProperty("orderClient")]
        public string OrderClient { get; set; }
        [JsonProperty("orderTotal")]
        public decimal OrderTotal { get; set; }
        [JsonProperty("orderStatus")]
        public string OrderStatus { get; set; }
        [JsonProperty("orderNote")]
        public string OrderNote { get; set; }
        [JsonProperty("salesMan")]
        public string SalesMan { get; set; }

        public string FormatedId 
        {
            get
            {
                if (string.IsNullOrWhiteSpace(OrderId))
                    return string.Empty;

                return OrderId.Remove(0, 4).TrimStart('0');
            }
        }
    }
}

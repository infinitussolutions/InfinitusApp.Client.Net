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


    }

    public class DrPeanutReturnFinancialRequest
    {
        [JsonProperty("numeroPedidoItSofitn")]
        public string FinancialRequestId { get; set; }

        [JsonProperty("valorDesconto")]
        public decimal TotalDiscount { get; set; }

        [JsonProperty("isCondicaoValida")]
        public bool ValidPaymentCondition { get; set; }
    }

    public class DrPeanutCustomerCommand : DrPeanutCommand
    {

    }

    public class DrPeanutCreateFinancialRequestCommand : DrPeanutCommand
    {
        [JsonProperty("numeroPedido")]
        public string FinancialRequestId { get; set; }
    }
}

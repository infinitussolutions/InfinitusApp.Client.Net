using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Custom.DrPeanut
{
    public class DrPeanutFinancialRequestCommand
    {
        [JsonProperty("numeroPedidoItSofitn")]
        public string FinancialRequestId { get; set; }

        [JsonProperty("totalPedido")]
        public decimal TotalRequest { get; set; }

        [JsonProperty("condicaoPgto")]
        public string PaymentConditionId { get; set; }

        [JsonProperty("token")]
        public string Token
        {
            get
            {
                return "32e73011-0387-4dd2-ade1-fffb53cfa133";
            }
        }
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
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.ExternalConnection;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu
{
    public class IuguCustomerCommand
    {
        public string DataStoreId { get; set; }
        public string ApplicationUserId { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        /// <summary>
        /// CPF or CNPJ
        /// </summary>
        public string DocumentNumber { get; set; }

      
    }

    #region Payment Methods

    public class IuguPaymentMethodCommand
    {
        public IuguPaymentMethodCommand()
        {
            ExternalConnectionType = ExternalConnectionType.IuguCustomer;
        }

        public string DataStoreId { get; set; }
        public string ApplicationUserId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("set_as_default")]
        public bool IsDefault { get; set; }
        [JsonProperty("customer_id")]
        public bool CustomerId { get; set; }
        public ExternalConnectionType ExternalConnectionType { get; set; }
    }

    public class CreateIuguPaymentMethodCommand : IuguPaymentMethodCommand
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        public CreateCreditCardTokenCommand CreditCard { get; set; }
    }

    public class UpdateIuguPaymentMethodCommand : IuguPaymentMethodCommand
    {

    }

    public class DeleteIuguPaymentMethodCommand
    {
        public DeleteIuguPaymentMethodCommand()
        {
            ExternalConnectionType = ExternalConnectionType.IuguCustomer;
        }

        public string DataStoreId { get; set; }
        public string ApplicationUserId { get; set; }

        [JsonProperty("id")]
        public string PaymentMethodId { get; set; }

        public ExternalConnectionType ExternalConnectionType { get; set; }
    }

    #endregion
}

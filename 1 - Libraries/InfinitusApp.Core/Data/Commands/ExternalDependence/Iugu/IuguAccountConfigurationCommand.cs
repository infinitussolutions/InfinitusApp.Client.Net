using InfinitusApp.Core.Data.DataModels.External.Iugu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu
{
    public class IuguAccountConfigurationCommand
    {
        public IuguAccountConfigurationCommand()
        {
            Commissions = new IuguCommissions();
            BankSlip = new IuguBankSlipConfiguration();
            CreditCard = new IuguCreditCardConfiguration();
        }

        public string MarketplaceId { get; set; }

        [JsonProperty("commissions")]
        public IuguCommissions Commissions { get; set; }
        [JsonProperty("bank_slip")]
        public IuguBankSlipConfiguration BankSlip { get; set; }
        [JsonProperty("credit_card")]
        public IuguCreditCardConfiguration CreditCard { get; set; }
        [JsonProperty("payment_email_notification")]
        public bool EmailNotification { get; set; }
        [JsonProperty("payment_email_notification_receiver")]
        public string EmailToNotify { get; set; }
    }

    public class IuguCreateAccountCommand
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        public string DataStoreId { get; set; }
        public string DataItemId { get; set; }
    }

    public class IuguValidateAccountCommand
    {
        public IuguValidateAccountCommand()
        {
            AccountData = new IuguAccountData();
        }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("data")]
        public IuguAccountData AccountData { get; set; }
        public string MarketplaceId { get; set; }
    }

}

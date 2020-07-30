using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Iugu
{

    public class IuguAccountData
    {
        [JsonProperty("price_range")]
        public string PriceRange { get { return "Mais que R$ 5,00"; } }
        [JsonProperty("physical_products")]
        public bool SellPhysicalProducts { get; set; }
        [JsonProperty("business_type")]
        public string BusinessDescription { get; set; }
        /// <summary>
        /// Pessoa Física || Pessoa Jurídica
        /// </summary>
        [JsonProperty("person_type")]
        public string AccountType { get; set; }
        [JsonProperty("automatic_transfer")]
        public bool AutomaticWithdrawal { get { return false; } }
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }
        [JsonProperty("cpf")]
        public string Cpf { get; set; }
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("name")]
        public string PersonName { get; set; }
        [JsonProperty("cep")]
        public string Cep { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("telephone")]
        public string Phone { get; set; }
        [JsonProperty("resp_name")]
        public string ResponsibleName { get; set; }
        [JsonProperty("resp_cpf")]
        public string ResponsibleCpf { get; set; }
        [JsonProperty("bank")]
        public string BankName { get; set; }
        [JsonProperty("bank_ag")]
        public string BankAgency { get; set; }
        [JsonProperty("account_type")]
        public string BankAccountType { get; set; }
        [JsonProperty("bank_cc")]
        public string BankAccountNumber { get; set; }
    }

    public class IuguRequestWithdrawCommand
    {
        [JsonProperty("id")]
        public string AccountId { get; set; }
        /// <summary>
        /// 500.0 para 500 reais
        /// </summary>
        [JsonProperty("amount")]
        public float Amount { get; set; }
        public string MarketplaceId { get; set; }
    }

    public class IuguRequestTransferCommand
    {
        [JsonProperty("receiver_id")]
        public string ReceiverId { get; set; }
        [JsonProperty("amount_cents")]
        public float Amount { get; set; }
    }

    public class IuguAccountRequestMessage
    {
        [JsonProperty("commissions")]
        public IuguCommissions Commissions { get; set; }
    }

    public class IuguCommissions
    {
        [JsonProperty("cents")]
        public int? Cents { get { return 0; } }
        [JsonProperty("credit_card_percent")]
        public float? CreditCardPercent { get; set; }
        [JsonProperty("bank_slip_cents")]
        public int? BankSlipCents { get; set; }
    }

    public class IuguBankSlipConfiguration
    {
        [JsonProperty("active")]
        public bool Active { get; set; }
    }

    public class IuguCreditCardConfiguration
    {
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("soft_descriptor")]
        public string InvoiceDescription { get; set; }
        [JsonProperty("installments")]
        public bool AllowInstallments { get; set; }
        /// <summary>
        /// 1 a 12
        /// </summary>
        [JsonProperty("max_installments")]
        public int MaxInstallments { get; set; }
    }

    public class IuguAccount
    {
        [JsonProperty("account_id")]
        public string Id { get; set; }
        [JsonProperty("live_api_token")]
        public string LiveToken { get; set; }
        [JsonProperty("test_api_token")]
        public string TestToken { get; set; }
        [JsonProperty("user_token")]
        public string UserToken { get; set; }
    }

    public class IuguAccountInfo
    {
        public IuguAccountInfo()
        {
            Configuration = new IuguConfiguration();
            Commisions = new IuguCommissions();
            VerificationRequestData = new IuguAccountData();
            Informations = new List<IuguAccountInformations>();
            LastWithdrawRequest = new IuguWithdrawAccountResponse();
        }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? LastUpdate { get; set; }
        [JsonProperty("can_receive?")]
        public bool CanReceive { get; set; }
        [JsonProperty("is_verified?")]
        public bool Verified { get; set; }
        [JsonProperty("last_verification_request_status")]
        public string VerifiedStatus { get; set; }
        [JsonProperty("last_verification_request_feedback")]
        public string VerifiedMessage { get; set; }
        [JsonProperty("balance_available_for_withdraw")]
        public string AvailableBalance { get; set; }
        [JsonProperty("configuration")]
        public IuguConfiguration Configuration { get; set; }
        [JsonProperty("commissions")]
        public IuguCommissions Commisions { get; set; }
        [JsonProperty("last_verification_request_data")]
        public IuguAccountData VerificationRequestData { get; set; }
        [JsonProperty("volume_this_month")]
        public string VolumeThisMonth { get; set; }
        [JsonProperty("volume_last_month")]
        public string VolumeLastMonth { get; set; }
        [JsonProperty("total_subscriptions")]
        public int TotalSubscriptions { get; set; }
        [JsonProperty("total_active_subscriptions")]
        public int TotalActiveSubscriptions { get; set; }
        [JsonProperty("balance_in_protest")]
        public string BalanceProtest { get; set; }
        [JsonProperty("balance")]
        public string Balance { get; set; }
        [JsonProperty("taxes_paid_this_month")]
        public string TaxesPaidThisMonth { get; set; }
        [JsonProperty("taxes_paid_last_month")]
        public string TaxesPaidLastMonth { get; set; }
        [JsonProperty("receivable_balance")]
        public string BalanceToReceive { get; set; }
        [JsonProperty("protected_balance")]
        public string BalanceProtected { get; set; }
        [JsonProperty("last_withdraw")]
        public IuguWithdrawAccountResponse LastWithdrawRequest { get; set; }
        [JsonProperty("informations")]
        public IList<IuguAccountInformations> Informations { get; set; }



    }

    public class IuguConfiguration
    {
        public IuguConfiguration()
        {
            BankSlip = new IuguBankSlipConfiguration();
            CreditCard = new IuguCreditCardConfiguration();
        }

        [JsonProperty("payment_email_notification")]
        public bool EmailNotification { get; set; }
        [JsonProperty("payment_email_notification_receiver")]
        public string EmailToNotify { get; set; }
        [JsonProperty("bank_slip")]
        public IuguBankSlipConfiguration BankSlip { get; set; }
        [JsonProperty("credit_card")]
        public IuguCreditCardConfiguration CreditCard { get; set; }
    }

    public class IuguAccountInformations
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class IuguWithdrawResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
    }


    public class IuguTransferResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("amount_localized")]
        public string Amount { get; set; }
    }

    public class IuguWithdrawAccountResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdateAt { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("feedback")]
        public string Feedback { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}

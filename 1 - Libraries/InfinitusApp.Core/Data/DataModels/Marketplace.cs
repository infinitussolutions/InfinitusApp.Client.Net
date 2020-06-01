using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Marketplace : EntityBase
    {
        public Marketplace()
        {
            PaymentInfo = new PaymentInfo();
            Iugu = new IuguMarketplace();
            InvoiceConfig = new InvoiceConfig();
            Ebanx = new EbanxMarketplace();
            InfinitusConfig = new InfinitusMarketplaceConfig();
        }

        public PaymentInfo PaymentInfo { get; set; }

        public InvoiceConfig InvoiceConfig { get; set; }

        public IuguMarketplace Iugu { get; set; }

        public EbanxMarketplace Ebanx { get; set; }

        public InfinitusMarketplaceConfig InfinitusConfig { get; set; }


        #region Relations

        public string DataStoreId { get; set; }

        public string DefaultFinancialOriginId { get; set; }

        public string DefaultCustomerId { get; set; }

        public string SalesmanUserId { get; set; }

        #endregion

        #region Helps

        public bool HasIugu
        {
            get
            {
                return !string.IsNullOrEmpty(Iugu?.AccountId);
            }
        }

        public bool HasEbanx
        {
            get
            {
                return !string.IsNullOrEmpty(Ebanx?.AccountId);
            }
        }
        #endregion

        public enum MarketplaceEnvironment
        {
            Test,
            Prod
        }
    }

    public class InvoiceConfig
    {
        public int MaxDaysToRefund { get; set; }
    }

    public class IuguMarketplace
    {
        /// <summary>
        /// Iugu Account Id
        /// </summary>
        public string AccountId { get; set; }
        public string LiveToken { get; set; }
        public string TestToken { get; set; }
        public string UserToken { get; set; }
        public bool InTest { get; set; }

        #region Helps

        [JsonIgnore]
        public string ActiveToken
        {
            get
            {
                return InTest ? TestToken : LiveToken;
            }
        }

        [JsonIgnore]
        public string EnvironmentPresentation
        {
            get
            {
                return InTest ? "Teste" : "Produção";
            }

        }

        #endregion
    }
    public class EbanxMarketplace
    {
        public EbanxMarketplace()
        {
            Fees = new MarketplaceFee();
        }

        public string AccountId { get; set; }
        public string RecipientCode { get; set; }
        public MarketplaceFee Fees { get; set; }
    }

    public class InfinitusMarketplaceConfig
    {
        public bool UseWhatsapp { get; set; }
    }

    public class MarketplaceFee
    {
        public MarketplaceFee()
        {
            BankSlip = new BankSlipFee();
            CreditCard = new CreditCardFee();
        }

        public BankSlipFee BankSlip { get; set; }
        public CreditCardFee CreditCard { get; set; }
    }

    public class BankSlipFee
    {
        public float AmountInfinitus { get; set; }
        public float AmountAppOwner { get; set; }
        public float Amount { get; set; }
    }

    public class CreditCardFee
    {
        public float PercentageInfinitus { get; set; }
        public float PercentageAppOwner { get; set; }
        public float Percentage { get; set; }

        public bool IsValid
        {
            get
            {
                return Percentage + PercentageAppOwner + PercentageInfinitus == 100;
            }
        }
    }
}

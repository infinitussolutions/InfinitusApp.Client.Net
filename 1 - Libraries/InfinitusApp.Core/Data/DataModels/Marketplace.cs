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
        }

        public PaymentInfo PaymentInfo { get; set; }

        public InvoiceConfig InvoiceConfig { get; set; }

        public IuguMarketplace Iugu { get; set; }

        public EbanxMarketplace Ebanx { get; set; }


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
        public string AccountId { get; set; }
    }
}

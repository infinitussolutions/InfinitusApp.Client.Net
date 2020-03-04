using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Configuration : EntityBase
    {
        public Configuration()
        {
            FinancialRequestConfiguration = new FinancialRequestConfiguration();
            FinancialDocumentConfiguration = new FinancialDocumentConfiguration();
            DataItemConfiguration = new DataItemConfiguration();
        }

        public FinancialRequestConfiguration FinancialRequestConfiguration { get; set; }

        public FinancialDocumentConfiguration FinancialDocumentConfiguration { get; set; }

        public DataItemConfiguration DataItemConfiguration { get; set; }

        #region Relations

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        #endregion

    }

    #region FinancialRequest

    public class FinancialRequestConfiguration
    {
        public FinancialRequestConfiguration()
        {
            SalesOrderConfiguration = new SalesOrderConfiguration();
            ManualInclusionConfiguration = new ManualInclusionConfiguration();
            SalesmanConfiguration = new SalesmanConfiguration();

        }

        public SalesOrderConfiguration SalesOrderConfiguration { get; set; }

        public ManualInclusionConfiguration ManualInclusionConfiguration { get; set; }

        public SalesmanConfiguration SalesmanConfiguration { get; set; }


    }

    public class SalesOrderConfiguration
    {
        public SalesOrderConfiguration()
        {
            TrackingCodeConfiguration = new TrackingCodeConfiguration();
        }

        public TrackingCodeConfiguration TrackingCodeConfiguration { get; set; }
    }

    public class ManualInclusionConfiguration
    {
        public ManualInclusionConfiguration()
        {
            TrackingCodeConfiguration = new TrackingCodeConfiguration();
        }

        public TrackingCodeConfiguration TrackingCodeConfiguration { get; set; }
    }

    public class TrackingCodeConfiguration
    {
        public int InitialNumber { get; set; }

        public string Letter { get; set; }
    }

    public class SalesmanConfiguration
    {
        public string CompanyUserGroupSalesmanId { get; set; }

        public string DefaultSalesmanUserId { get; set; }
    }

    #endregion

    #region Document

    public class FinancialDocumentConfiguration
    {
        public FinancialDocumentConfiguration()
        {
            FinancialDocumentTypeNfeConfiguration = new FinancialDocumentTypeNfeConfiguration();
            FinancialDocumentTypeManualConfiguration = new FinancialDocumentTypeManualConfiguration();
        }

        public FinancialDocumentTypeNfeConfiguration FinancialDocumentTypeNfeConfiguration { get; set; }

        public FinancialDocumentTypeManualConfiguration FinancialDocumentTypeManualConfiguration { get; set; }
    }

    public class FinancialDocumentTypeNfeConfiguration
    {
        public FinancialDocumentTypeNfeConfiguration()
        {
            NumberAndSerieConfiguration = new NumberAndSerieConfiguration();
        }

        public NumberAndSerieConfiguration NumberAndSerieConfiguration { get; set; }
    }

    public class FinancialDocumentTypeManualConfiguration
    {
        public FinancialDocumentTypeManualConfiguration()
        {
            NumberAndSerieConfiguration = new NumberAndSerieConfiguration();
        }

        public NumberAndSerieConfiguration NumberAndSerieConfiguration { get; set; }
    }

    public class NumberAndSerieConfiguration
    {
        public int InitialNumber { get; set; }

        public string Serie { get; set; }
    }

    #endregion

    #region DataItem

    public class DataItemConfiguration
    {
        public DataItemConfiguration()
        {
            Product = new DataItemProductConfiguration();
            Price = new DataItemPriceInfo();
        }

        public DataItemProductConfiguration Product { get; set; }
        public DataItemPriceInfo Price { get; set; }
    }

    public class DataItemProductConfiguration
    {
        public DataItemProductConfiguration()
        {
            InitialCode = new IdentificationCode();
        }

        public IdentificationCode InitialCode { get; set; }

        public bool UseManualCode { get; set; }

    }

    #endregion
}

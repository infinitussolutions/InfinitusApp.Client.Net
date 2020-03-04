using System;
using System.Collections.Generic;

namespace InfinitusApp.Core.Data.DataModels
{
    public class DataStore : Naylah.Core.Entities.EntityBase
    {
        public DataStore()
        {
            Items = new List<DataItem>();
            Customers = new List<Customer>();
            PaymentConditions = new List<PaymentCondition>();
            PaymentMethods = new List<PaymentMethod>();
            SalesOrders = new List<FinancialRequest>();
            Leads = new List<Lead>();
            FinancialParameters = new FinancialParameters();
        }

        public IList<DataItem> Items { get; set; }
        public IList<Customer> Customers { get; set; }
        public IList<PaymentCondition> PaymentConditions { get; set; }
        public IList<PaymentMethod> PaymentMethods { get; set; }
        public IList<FinancialRequest> SalesOrders { get; set; }
        public IList<Lead> Leads { get; set; }
        public FinancialParameters FinancialParameters { get; set; }
        #region Obsolete
        [Obsolete("Use FinancialParameters")]
        public string CompanyUserGroupSalesmanId { get; set; }
        [Obsolete("Use FinancialParameters")]
        public string DefaultSalesmanId { get; set; }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialParameters
    {
        public FinancialParameters()
        {
            PaymentInfo = new PaymentInfo();
        }

        public string DefaultOriginIdToApp { get; set; }
        public string DefaultSalesmanId { get; set; }
        public string CompanyUserGroupSalesmanId { get; set; }
        public string DefaultCustomerId { get; set; }
        public int MaxDaysToRefund { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }
}

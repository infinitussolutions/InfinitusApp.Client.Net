using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.DataStore
{
    public class FinancialParametersCommand
    {
        public string DefaultOriginIdToApp { get; set; }
        public string DefaultSalesmanId { get; set; }
        public string CompanyUserGroupSalesmanId { get; set; }
        public string DefaultCustomerId { get; set; }
        public int MaxDaysToRefund { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }

    public class UpdateFinancialParametersCommand : FinancialParametersCommand
    {
        public string DataStoreId { get; set; }
    }
}

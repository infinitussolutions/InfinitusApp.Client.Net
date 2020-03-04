using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data
{
    public class Expense
    {
        public Expense()
        {
            InputInfo = new ExpenseInputInfo();
            OutPutInfo = new ExpenseOutputInfo();
        }

        public ExpenseInputInfo InputInfo { get; set; }

        public ExpenseOutputInfo OutPutInfo { get; set; }
    }

    public class ExpenseInputInfo
    {
        public ExpenseInputInfo()
        {
            FiscalDocument = new FiscalDocument();
        }

        public decimal Total { get; set; }

        public FiscalDocument FiscalDocument { get; set; }

        public bool HasFiscalDocument { get { return !string.IsNullOrEmpty(FiscalDocument?.AccessKey); } }
    }

    public class ExpenseOutputInfo
    {
        public decimal Total { get; set; }
    }
}

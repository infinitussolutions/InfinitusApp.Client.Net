using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class BankAccount
    {
        public string Bank { get; set; }

        public string Agency { get; set; }

        public string Type { get; set; }

        public string Number { get; set; }

        
    }

    public class BankAccountType
    {
        public BankAccountTypes AccountType { get; set; }
        public string AccountTypePresentation
        {
            get
            {
                switch (AccountType)
                {
                    case BankAccountTypes.Current: return "Conta Corrente";
                    case BankAccountTypes.Savings: return "Conta Poupança";
                    default: return string.Empty;
                }
            }
        }
        

        public enum BankAccountTypes
        {
            Current,
            Savings
        }
    }

}

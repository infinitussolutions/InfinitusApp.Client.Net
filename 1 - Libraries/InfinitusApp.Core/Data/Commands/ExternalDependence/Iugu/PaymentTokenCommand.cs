using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu
{
    public class PaymentTokenCommand
    {
        public bool IsTest { get; set; }
        public string FullName { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Number { get; set; }
        public string VerificationValue { get; set; }
        public string FirstName
        {
            get
            {
                string[] names = FullName.Split(" ".ToCharArray(), 2);
                return names[0];
            }
        }

        public string LastName
        {
            get
            {
                string[] names = FullName.Split(" ".ToCharArray(), 2);
                return names[1];
            }
        }
    }

    public class CreateCreditCardTokenCommand : PaymentTokenCommand
    {
        public string SubscriptionId { get; set; }
    }
}

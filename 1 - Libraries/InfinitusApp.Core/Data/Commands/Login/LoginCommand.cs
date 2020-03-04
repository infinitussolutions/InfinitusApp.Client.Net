using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Login
{
    public class LoginCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public CompanyLogon Company { get; set; }

        public enum CompanyLogon
        {
            Default,
            Mannesoft,
            PrimeApp,
            Bionostic
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu
{
    public class IuguCustomerCommand
    {
        public string DataStoreId { get; set; }
        public string ApplicationUserId { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        /// <summary>
        /// CPF or CNPJ
        /// </summary>
        public string DocumentNumber { get; set; }

    }
}

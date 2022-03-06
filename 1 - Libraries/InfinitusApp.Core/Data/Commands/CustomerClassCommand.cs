using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class CustomerClassCommand
    {
        public string Description { get; set; }
        public string ExternalCode { get; set; }
    }

    public class CreateCustomerClassCommand : CustomerClassCommand
    {
        public string DataStoreId { get; set; }
    }

    public class UpdateCustomerClassCommand : CustomerClassCommand
    {
        public string Id { get; set; }
    }
}

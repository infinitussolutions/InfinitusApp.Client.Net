using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class CustomerTypeCommand
    {
        public string Description { get; set; }
    }

    public class CreateCustomerTypeCommand : CustomerTypeCommand
    {
        public string DataStoreId { get; set; }
    }

    public class UpdateCustomerTypeCommand : CustomerTypeCommand
    {
        public string Id { get; set; }
    }
}

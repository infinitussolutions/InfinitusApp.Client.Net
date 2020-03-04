using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class DeliveryFeeCommand
    {
        public double Kilometer { get; set; }

        public Price Price { get; set; }
    }

    public class CreateDeliveryFeeCommand : DeliveryFeeCommand
    {
        public string DataItemId { get; set; }

        public string DataStoreId { get; set; }
    }

    public class UpdateDeliveryFeeCommand : DeliveryFeeCommand
    {
        public string Id { get; set; }
    }
}

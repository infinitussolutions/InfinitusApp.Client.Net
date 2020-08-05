using InfinitusApp.Core.Data.DataModels.External.Iugu;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu
{
    public class IuguPlanCommand
    {
        public string MarketplaceId { get; set; }
        public PlanRequestMessage IuguCommand { get; set; }
    }


    public class CreateIuguPlanCommand : IuguPlanCommand
    {
        public string SignaturePlanId { get; set; }
    }

    public class UpdateIuguPlanCommand : IuguPlanCommand
    {

        public string PlanId { get; set; }
    }

    public class DeleteIuguPlanCommand
    {
        public string PlanId { get; set; }
        public string MarketplaceId { get; set; }
    }
}

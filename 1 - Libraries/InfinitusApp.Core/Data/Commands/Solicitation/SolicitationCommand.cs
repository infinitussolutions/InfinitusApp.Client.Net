using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.Solicitation;

namespace InfinitusApp.Core.Data.Commands.Solicitation
{
    public class SolicitationCommand
    {
        public string Description { get; set; }
        public string Comment { get; set; }
        public SolicitationStatus Status { get; set; }
    }
}

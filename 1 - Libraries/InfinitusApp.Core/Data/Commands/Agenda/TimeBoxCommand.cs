using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Agenda
{
    public class TimeBoxCommand
    {
        public string DataItemId { get; set; }
        public DateTime? Start { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Agenda
{
    public class ScheduleConfigCommand
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }

    public class ScheduleConfigCreateCommand : ScheduleConfigCommand
    {
        public DayOfWeek DayOfWeek { get; set; }
    }

    public class ScheduleConfigUpdateCommand : ScheduleConfigCommand
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
    }
}

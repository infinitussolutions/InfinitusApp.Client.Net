using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Agenda
{
    public class ScheduleCommand
    {
        public bool IsDefault { get; set; }
        public string Description { get; set; }
        public string TimeZoneInfoId { get; set; }
        public int DaysLimit { get; set; }
    }

    public class ScheduleCreateCommand : ScheduleCommand
    {
        public ScheduleCreateCommand()
        {
            Configs = new List<ScheduleConfigCreateCommand>();
        }

        public string DataStoreId { get; set; }

        public List<ScheduleConfigCreateCommand> Configs { get; set; }
    }

    public class ScheduleUpdateCommand : ScheduleCommand
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
    }
}

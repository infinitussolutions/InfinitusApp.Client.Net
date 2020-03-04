using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Agenda
{
    public class ScheduleBreakCommand
    {
        public DaysOfWeek Days { get; set; }
        public TimeSpan Start { get; set; }
        /// <summary>
        /// TimeSpent in minutes
        /// </summary>
        public int TimeSpent { get; set; }
        public string Description { get; set; }
    }

    public class ScheduleBreakCreateCommand : ScheduleBreakCommand
    {
        public string ScheduleId { get; set; }
    }

    public class ScheduleBreakUpdateCommand : ScheduleBreakCommand
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
    }
}

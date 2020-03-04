using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Agenda
{
    public class ScheduleResponsibleCommand
    {

    }

    public class ScheduleResponsibleCreateCommand : ScheduleResponsibleCommand
    {
        public string ScheduleConfigId { get; set; }
        public string DataItemId { get; set; }
    }

    public class ScheduleResponsibleUpdateCommand : ScheduleResponsibleCommand
    {
        public string Id { get; set; }
    }
}

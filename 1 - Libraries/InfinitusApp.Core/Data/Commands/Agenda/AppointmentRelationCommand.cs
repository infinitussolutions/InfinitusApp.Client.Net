using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.AppointmentRelation;

namespace InfinitusApp.Core.Data.Commands.Agenda
{
    public class AppointmentRelationCommand
    {
        public AppontmentRelationType RelationType { get; set; }
    }

    public class AppointmentRelationCreateCommand : AppointmentRelationCommand
    {
        public string AppointmentId { get; set; }
        public string DataItemId { get; set; }
    }

    public class AppointmentRelationUpdateCommand : AppointmentRelationCommand
    {
        public string Id { get; set; }
    }
}

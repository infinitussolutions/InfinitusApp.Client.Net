using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.Appointment;

namespace InfinitusApp.Core.Data.Commands.Agenda
{
    public class AppointmentCommand
    {
        public DateTimeOffset Start { get; set; }
        public string Observation { get; set; }
        public string ResponsibleId { get; set; }
        public AddressComplex Address { get; set; }
    }

    public class AppointmentCreateCommand : AppointmentCommand
    {
        public UserReference User { get; set; }
        public bool IsReturn { get; set; }
        public string DataItemId { get; set; }
        public int Duration { get; set; }
        public string RelatedDataItemId { get; set; }
        public string DataStoreId { get; set; }
    }

    public class AppointmentUpdateCommand : AppointmentCommand
    {
        public string Id { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    public class AppointmentFilterCommand
    {
        public string DataItemId { get; set; }
        public string DataStoreId { get; set; }
        /// <summary>
        /// If null, the first day of the month shall be used
        /// </summary>
        public DateTime? Start { get; set; }
        /// <summary>
        /// If null, the last day of the month shall be used
        /// </summary>
        public DateTime? End { get; set; }
    }
}

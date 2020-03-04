using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class AppointmentRelation : EntityBase
    {
        public AppointmentRelation()
        {

        }

        public AppontmentRelationType RelationType { get; set; }

        public Appointment Appointment { get; set; }
        public string AppointmentId { get; set; }
        public DataItem DataItem { get; set; }
        public string DataItemId { get; set; }

        public enum AppontmentRelationType
        {
            Related
        }
    }
}

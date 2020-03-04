using System;

namespace InfinitusApp.Core.Data.DataModels
{
    public class DateTimeZonePeriod
    {
        public DateTimeZone Start { get; set; }

        public DateTimeZone End { get; set; }

        public TimeSpan Duration { get; set; }

        //public string AgendaId { get; set; }
    }
}
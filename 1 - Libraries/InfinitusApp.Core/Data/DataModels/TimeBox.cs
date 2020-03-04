using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class TimeBox
    {
        public bool Busy { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }

        public string HourPresentation 
        {
            get
            {
                return string.Format("{0} às {1}", Start.ToString("HH:mm"), End.ToString("HH:mm"));
            }
        }

        public string PeriodPresentation
        {
            get
            {
                return Start.Hour < 12 ? "Manhã" : "Tarde";
            }
        }
    }
}

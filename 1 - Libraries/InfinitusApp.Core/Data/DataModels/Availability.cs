using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Availability
    {
        public Availability()
        {
            DaysAvailable = new DaysOfWeek();
        }

        public DaysOfWeek DaysAvailable { get; set; }

    }
}

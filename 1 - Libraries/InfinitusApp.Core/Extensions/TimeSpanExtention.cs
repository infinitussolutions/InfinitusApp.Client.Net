using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InfinitusApp.Core.Extensions
{
    public static class TimeSpanExtention
    {
        public static bool IsBetween(this TimeSpan time, TimeSpan start, TimeSpan end)
        {
            // convert datetime to a TimeSpan
            var now = time; //datetime.TimeOfDay;
            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }
    }
}

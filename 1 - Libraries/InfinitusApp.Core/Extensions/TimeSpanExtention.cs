using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InfinitusApp.Core.Extensions
{
    public static class TimeSpanExtention
    {
        public static bool IsBetween(this TimeSpan timeSpanToCheck, TimeSpan start, TimeSpan end)
        {
            return timeSpanToCheck >= start && timeSpanToCheck <= end;
        }
    }
}

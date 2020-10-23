using System;
using System.Collections.Generic;
using System.Linq;

namespace InfinitusApp.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTimeRange> GetIntervalBetween(DateTime from, TimeSpan interval, DateTime to)
        {
            var list = new List<DateTimeRange>();

            var currentFrom = from;
            var currentTo = from.Add(interval);

            while (currentTo <= to)
            {
                list.Add(DateTimeRange.Create(currentFrom, currentTo));
                currentFrom = currentTo;
                currentTo = currentFrom.Add(interval);
            }

            return list;
        }

        public static IEnumerable<DateTimeRange> GetIntervalsUntil(this DateTime from, TimeSpan interval, DateTime to)
        {
            return GetIntervalBetween(from, interval, to);
        }

        //public static DateTime SetBrasilia(this DateTime datetime)
        //{
        //    return datetime.ToLocalTime();
        //}
    }

    public class DateTimeRange
    {
        public DateTimeRange()
        {
        }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public static DateTimeRange Create(DateTime start, DateTime end)
        {
            var dtr = new DateTimeRange();
            dtr.Start = start;
            dtr.End = end;

            return dtr;
        }
    }
}
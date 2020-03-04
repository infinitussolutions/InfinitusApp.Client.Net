using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InfinitusApp.Core.Extensions
{
    public static class DateExtention
    {
        public static TimeSpan CalculatePeriod(TimeSpan start, TimeSpan end)
        {
            try
            {
                var totalDuration = new TimeSpan();

                if (end < start)
                {
                    var dtStart = DateTime.Now.Date.Add(start);

                    var dtEnd = DateTime.Now.Date.AddDays(1).Add(end);

                    totalDuration = dtEnd.Subtract(dtStart);
                }

                else
                    totalDuration = end - start;

                return totalDuration;
            }

            catch (Exception)
            {
                return new TimeSpan();
            }

        }

        public static string ToPresentation(this DateTime dateTime, bool isSimple = false)
        {
            if (isSimple)
                return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(dateTime.DayOfWeek) + ", " + dateTime.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(dateTime.Month) + " de " + dateTime.ToString("yyyy");

            return DateTimeFormatInfo.CurrentInfo.GetDayName(dateTime.DayOfWeek) + ", " + dateTime.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(dateTime.Month) + " de " + dateTime.ToString("yyyy");
        }

        public static string ToPresentation(this DateTimeOffset dateTime, bool isSimple = false)
        {
            if (isSimple)
                return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(dateTime.DayOfWeek) + ", " + dateTime.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(dateTime.Month) + " de " + dateTime.ToString("yyyy");

            return DateTimeFormatInfo.CurrentInfo.GetDayName(dateTime.DayOfWeek) + ", " + dateTime.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(dateTime.Month) + " de " + dateTime.ToString("yyyy");
        }
    }
}

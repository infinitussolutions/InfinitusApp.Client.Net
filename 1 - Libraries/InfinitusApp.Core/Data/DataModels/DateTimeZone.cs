using System;

namespace InfinitusApp.Core.Data.DataModels
{
    public class DateTimeZone
    {
        public DateTime DateTime { get; set; }
        public string TimeZoneInfoId { get; set; }

        public TimeZoneInfo TimeZoneInfo
        {
            get
            {
                var infoId = string.IsNullOrEmpty(TimeZoneInfoId) ? "UTC" : TimeZoneInfoId;

                return TimeZoneInfo.FindSystemTimeZoneById(infoId);
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class DaysOfWeek
    {
        public DaysOfWeek()
        {
            Days = new List<DayOfWeek>();
        }

        public IList<DayOfWeek> Days { get; set; }

        #region Helps

        [JsonIgnore]
        public bool HasConfig { get { return Days != null && Days.Count > 0; } }

        [JsonIgnore]
        public DaysOfWeekHelper AvailableDaysOfWeak
        {
            get
            {
                if (!HasConfig)
                    return new DaysOfWeekHelper();

                return new DaysOfWeekHelper
                {
                    HasFriday = Days.Any(x => x == DayOfWeek.Friday),
                    HasMonday = Days.Any(x => x == DayOfWeek.Monday),
                    HasSaturday = Days.Any(x => x == DayOfWeek.Saturday),
                    HasSunday = Days.Any(x => x == DayOfWeek.Sunday),
                    HasThursday = Days.Any(x => x == DayOfWeek.Thursday),
                    HasTuesday = Days.Any(x => x == DayOfWeek.Tuesday),
                    HasWednesday = Days.Any(x => x == DayOfWeek.Wednesday),
                    HasToday = Days.Any(x => x == DateTime.Now.DayOfWeek)
                };
            }
        }

        #endregion
    }

    public class DaysOfWeekHelper
    {
        public bool HasMonday { get; set; }
        public bool HasFriday { get; set; }
        public bool HasSaturday { get; set; }
        public bool HasSunday { get; set; }
        public bool HasThursday { get; set; }
        public bool HasTuesday { get; set; }
        public bool HasWednesday { get; set; }
        public bool HasToday { get; set; }
    }

    public static class DayOfWeekExtend
    {
        public static string ToPresentation(this DayOfWeek dayOfWeek, bool isResume = false)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    return isResume ? "SEX " : "Sexta-Feira";
                case DayOfWeek.Monday:
                    return isResume ? "SEG" : "Segunda-Feira";
                case DayOfWeek.Saturday:
                    return isResume ? "SÁB" : "Sábado";
                case DayOfWeek.Sunday:
                    return isResume ? "DOM " : "Domingo";
                case DayOfWeek.Thursday:
                    return isResume ? "QUI " : "Quinta-Feira";
                case DayOfWeek.Tuesday:
                    return isResume ? "TER " : "Terça-Feira";
                case DayOfWeek.Wednesday:
                    return isResume ? "QUA " : "Quarta-Feira";
                default:
                    return "";
            }
        }
    }

}

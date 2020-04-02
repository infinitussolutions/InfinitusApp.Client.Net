using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class OpeningHours
    {
        public OpeningHours()
        {
            Sunday = new WorkingDay();
            Monday = new WorkingDay();
            Tuesday = new WorkingDay();
            Wednesday = new WorkingDay();
            Thursday = new WorkingDay();
            Friday = new WorkingDay();
            Saturday = new WorkingDay();
        }
        /// <summary>
        /// Domingo
        /// </summary>
        public WorkingDay Sunday { get; set; }
        /// <summary>
        /// Segunda
        /// </summary>
        public WorkingDay Monday { get; set; }
        /// <summary>
        /// Terça
        /// </summary>
        public WorkingDay Tuesday { get; set; }
        /// <summary>
        /// Quarta
        /// </summary>
        public WorkingDay Wednesday { get; set; }
        /// <summary>
        /// Quinta
        /// </summary>
        public WorkingDay Thursday { get; set; }
        /// <summary>
        /// Sexta
        /// </summary>
        public WorkingDay Friday { get; set; }
        /// <summary>
        /// Sábado
        /// </summary>
        public WorkingDay Saturday { get; set; }

        public WorkingDay CurrentDay
        {
            get
            {
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Monday: return Monday;
                    case DayOfWeek.Tuesday: return Tuesday;
                    case DayOfWeek.Wednesday: return Wednesday;
                    case DayOfWeek.Thursday: return Thursday;
                    case DayOfWeek.Friday: return Friday;
                    case DayOfWeek.Saturday: return Saturday;
                    case DayOfWeek.Sunday: return Sunday;
                    default: return null;
                }
            }
        }

        public bool IsOpen
        {
            get
            {
                if (CurrentDay == null)
                    return false;

                return DateTime.Now.TimeOfDay >= CurrentDay.Start && DateTime.Now.TimeOfDay < CurrentDay.End;
            }
        }
    }

    public class WorkingDay
    {
        public bool IsOpen { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}

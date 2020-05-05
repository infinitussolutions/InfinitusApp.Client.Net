using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Helps

        public List<WorkingDay> ListDays
        {
            get
            {
                return new List<WorkingDay>
                {
                    Sunday,
                    Monday,
                    Tuesday,
                    Wednesday,
                    Thursday,
                    Friday,
                    Saturday
                };
            }
        }

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

        public WorkingDay NextOpenDay
        {
            get
            {
                if (!HasConfiguration)
                    return null;

                var dayIndex = (int)DateTime.Now.DayOfWeek + 1;

                for (int i = 0; i < 7; i++)
                {
                    if (dayIndex == 7)
                        dayIndex = 0;

                    if (ListDays[dayIndex].IsOpen)
                    {
                        ListDays[dayIndex].DayOfWeek = (DayOfWeek)dayIndex;

                        return ListDays[dayIndex];
                    }

                    dayIndex++;
                }

                return null;

            }
        }

        public bool CurrentDayIsOpen
        {
            get
            {
                if (CurrentDay == null || !CurrentDay.IsOpen)
                    return false;

                return DateTime.Now.TimeOfDay >= CurrentDay.Start && DateTime.Now.TimeOfDay < CurrentDay.End;
            }
        }

        public bool HasConfiguration
        {
            get
            {
                return ListDays.Any(x => x.IsOpen);
            }
        }

        public string DaysPresentation
        {
            get
            {
                return string.Format(
                    "Segunda: {0}\n" +
                    "Terça: {1}\n" +
                    "Quarta: {2}\n" +
                    "Quinta: {3}\n" +
                    "Sexta: {4}\n" +
                    "Sábado: {5}\n" +
                    "Domingo: {6}",
                    Monday.PeriodPresentation,
                    Tuesday.PeriodPresentation,
                    Wednesday.PeriodPresentation,
                    Thursday.PeriodPresentation,
                    Friday.PeriodPresentation,
                    Saturday.PeriodPresentation,
                    Sunday.PeriodPresentation
                    );
            }
        }


        #endregion
    }

    public class WorkingDay
    {
        public bool IsOpen { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public DayOfWeek? DayOfWeek { get; set; }

        #region Presentation

        public string IsOpenPresentation
        {
            get
            {
                return IsOpen ? "Aberto" : "Fechado";
            }
        }

        public string PeriodPresentation
        {
            get
            {
                if (!IsOpen)
                    return "Fechado";

                return string.Format("{0} - {1}", StartPresentation, EndPresentation);
            }
        }

        public string StartPresentation
        {
            get
            {
                return Start.ToString("hh':'mm");
            }
        }

        public string EndPresentation
        {
            get
            {
                return End.ToString("hh':'mm");
            }
        }

        public bool IsValid
        {
            get
            {
                return Start <= End;
            }
        }

        public static string GetDayPresentation(int day)
        {
            switch (day)
            {
                case 1: return "Segunda-Feira";
                case 2: return "Terça-Feira";
                case 3: return "Quarta-Feira";
                case 4: return "Quinta-Feira";
                case 5: return "Sexta-Feira";
                case 6: return "Sábado";
                case 7: return "Domingo";
                default: return "Valor inválido";
            }
        }

        #endregion
    }
}

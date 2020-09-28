using InfinitusApp.Core.Extensions;
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

        public List<WorkingDay> ListDaysWhereIsOpen => ListDays.Where(x => x.IsOpen).ToList();


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

        public string DaysPresentation => string.Format(
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


        public string DaysPresentationInLine
        {
            get
            {
                if (!HasConfiguration)
                    return "Informação não encontrada";

                var msg = "";

                foreach (var d in ListDaysWhereIsOpen)
                {
                    msg += d.PeriodPresentationWithDayOfWeek + " | ";
                }

                //if (Monday.IsOpen)
                //    msg += "Seg: " + Monday.PeriodPresentation;

                //if (Tuesday.IsOpen)
                //    msg += " | Ter: " + Tuesday.PeriodPresentation;

                //if (Wednesday.IsOpen)
                //    msg += " | Qua: " + Wednesday.PeriodPresentation;

                //if (Thursday.IsOpen)
                //    msg += " | Qui: " + Thursday.PeriodPresentation;

                //if (Friday.IsOpen)
                //    msg += " | Sex: " + Friday.PeriodPresentation;

                //if (Saturday.IsOpen)
                //    msg += " | Sab: " + Saturday.PeriodPresentation;

                //if (Sunday.IsOpen)
                //    msg += " | Dom: " + Sunday.PeriodPresentation;

                return msg;
            }
        }

        public string DaysPresentationWithTodayInLine
        {
            get
            {
                if (!HasConfiguration)
                    return "Informação não encontrada";

                var msg = "";

                var listOrder = ListDaysWhereIsOpen.OrderBy(x => x.DayOfWeek).ThenBy(x => x.IsTomorrow).ThenBy(x => x.IsToday);

                foreach (var d in listOrder)
                {
                    msg += d.PeriodPresentationWithDayOfWeekWithTodayInfo + " | ";
                }

                return msg;
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

        public string IsOpenPresentation => IsOpen ? "Aberto" : "Fechado";

        public string PeriodPresentation
        {
            get
            {
                if (!IsOpen)
                    return "Fechado";

                return string.Format("{0} - {1}", StartPresentation, EndPresentation);
            }
        }

        public string PeriodPresentationWithDayOfWeek => DayOfWeek.HasValue ? DayOfWeek.Value.GetPresentation(true) + ": " + StartPresentation + " - " + EndPresentation : "";

        public string PeriodPresentationWithDayOfWeekWithTodayInfo => DayOfWeek.HasValue ? (IsToday ? "Hoje" : IsTomorrow ? "Amanhã" : DayOfWeek.Value.GetPresentation(true)) + ": " + StartPresentation + " - " + EndPresentation : "";

        public string StartPresentation => Start.ToString("hh':'mm");

        public string EndPresentation => End.ToString("hh':'mm");

        public bool IsValid => Start <= End;

        public bool IsToday => DayOfWeek.HasValue && DateTime.Today.DayOfWeek.Equals(DayOfWeek.Value);

        public bool IsTomorrow => DayOfWeek.HasValue && DateTime.Today.AddDays(1).DayOfWeek.Equals(DayOfWeek.Value);

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

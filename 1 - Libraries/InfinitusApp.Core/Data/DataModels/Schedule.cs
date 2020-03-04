using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Schedule : EntityBase
    {
        public Schedule()
        {
            Schedules = new List<ScheduleConfig>();
            DataItems = new List<DataItem>();
            Breaks = new List<ScheduleBreak>();
        }

        public bool IsDefault { get; set; }

        public string Description { get; set; }

        public string TimeZoneInfoId { get; set; }

        public int DaysLimit { get; set; }

        #region Relations
        public IList<ScheduleConfig> Schedules { get; set; }
        public DataStore DataStore { get; set; }
        public string DataStoreId { get; set; }
        public IList<DataItem> DataItems { get; set; }
        public IList<ScheduleBreak> Breaks { get; set; }

        #endregion

        #region Helps

        public TimeZoneInfo TimeZoneInfo
        {
            get
            {
                try
                {
                    var infoId = string.IsNullOrEmpty(TimeZoneInfoId) ? "E. South America Standard Time" : TimeZoneInfoId;

                    return TimeZoneInfo.FindSystemTimeZoneById(infoId);
                }

                catch(Exception e)
                {
                    return TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
                }
            }
        }

        public string ScheduleWithConfigPresentation
        {
            get
            {
                var msgReturn = "";

                var minValue = new TimeSpan(0, 0, 0);

                Schedules = Schedules.OrderBy(x => x.DayOfWeek).ToList();

                foreach (var item in Schedules)
                {

                    var start = item.Start != minValue ? new DateTime(item.Start.Ticks).ToString("HH:mm tt") : "";
                    var end = item.End != minValue ? new DateTime(item.End.Ticks).ToString("HH:mm tt") : "";

                    //if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                    var time = start + " às " + end + "\n";

                    switch (item.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                                msgReturn += "SEG: " + time;
                            break;
                        case DayOfWeek.Tuesday:
                            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                                msgReturn += "TER: " + time;
                            break;
                        case DayOfWeek.Wednesday:
                            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                                msgReturn += "QUA: " + time;
                            break;
                        case DayOfWeek.Thursday:
                            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                                msgReturn += "QUI: " + time;
                            break;
                        case DayOfWeek.Friday:
                            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                                msgReturn += "SEX: " + time;
                            break;
                        case DayOfWeek.Saturday:
                            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                                msgReturn += "SÁB: " + time;
                            break;
                        case DayOfWeek.Sunday:
                            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                                msgReturn += "DOM: " + time;
                            break;
                    }
                }

                return msgReturn;
            }
        }

        public string DescriptionAndConfigPresentation
        {
            get
            {
                if (Deleted)
                    return string.Empty;

                return ScheduleWithConfigPresentation.Replace("\n", " | ");
            }
        }

        public string SelectedSchedulePresentation
        {
            get
            {
                return "Horário Selecionado: " + DescriptionAndConfigPresentation;
            }
        }

        [JsonIgnore]
        public bool AvailableNow
        {
            get
            {
                if (Schedules?.Count == 0 || ScheduleConfigOfTheDay == null)
                    return false;

                var schedule = Schedules.FirstOrDefault(x => x.DayOfWeek == DateTime.Now.DayOfWeek);

                return DateTime.Now > schedule.StartTime && DateTime.Now < schedule.EndTime;
            }
        }
        [JsonIgnore]
        public ScheduleConfig ScheduleConfigOfTheDay
        {
            get
            {
                if (Schedules == null)
                    return null;

                return Schedules.FirstOrDefault(x => x.DayOfWeek == DateTime.Now.DayOfWeek);
            }
        }
        #endregion
    }

    public class ScheduleConfig : EntityBase
    {
        public ScheduleConfig()
        {
            Responsibles = new List<ScheduleResponsible>();
        }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        #region Relations

        public Schedule Schedule { get; set; }
        public string ScheduleId { get; set; }

        public IList<ScheduleResponsible> Responsibles { get; set; }
        #endregion

        #region Helps

        [JsonIgnore]
        public DateTime StartTime
        {
            get
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Start.Hours, Start.Minutes, 0);
            }
        }

        [JsonIgnore]
        public DateTime EndTime
        {
            get
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, End.Hours, End.Minutes, 0);
            }
        }

        #endregion
    }

    public class ScheduleBreak : EntityBase
    {
        public ScheduleBreak()
        {
            Days = new DaysOfWeek();
        }

        public DaysOfWeek Days { get; set; }
        public TimeSpan Start { get; set; }
        /// <summary>
        /// TimeSpent in minutes
        /// </summary>
        public int TimeSpent { get; set; }
        public string Description { get; set; }

        public TimeSpan End
        {
            get
            {
                return Start != null ? Start.Add(new TimeSpan(0, TimeSpent, 0)) : new TimeSpan();
            }
        }

        #region Relations

        public Schedule Schedule { get; set; }
        public string ScheduleId { get; set; }

        #endregion
    }

    public class ScheduleResponsible : EntityBase
    {
        public ScheduleResponsible()
        {
            Appointments = new List<Appointment>();
        }

        public ScheduleConfig ScheduleConfig { get; set; }
        public string ScheduleConfigId { get; set; }
        public DataItem DataItem { get; set; }
        public string DataItemId { get; set; }
        public IList<Appointment> Appointments { get; set; }

        #region Helps
        [JsonIgnore]
        public string Title
        {
            get
            {
                if (DataItem?.Description == null)
                    return string.Empty;

                return DataItem.Description.Title;
            }
        }

        #endregion
    }
}
using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Appointment : EntityBase
    {
        public Appointment()
        {
            User = new UserReference();
            AdditionalInfos = new List<AdditionalInfo>();
            Relations = new List<AppointmentRelation>();
            Address = new AddressComplex();
        }

        public DateTimeOffset Start { get; set; }

        public AppointmentStatus Status { get; set; }

        public bool IsReturn { get; set; }

        public string Observation { get; set; }

        public UserReference User { get; set; }

        /// <summary>
        /// Minutes
        /// </summary>
        public int Duration { get; set; }

        #region Relations

        public DataItem DataItem { get; set; }
        public string DataItemId { get; set; }

        public ScheduleResponsible Responsible { get; set; }
        public string ResponsibleId { get; set; }

        public IList<AdditionalInfo> AdditionalInfos { get; set; }

        public IList<AppointmentRelation> Relations { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public AddressComplex Address { get; set; }
        #endregion

        #region Helps

        public DateTimeOffset End
        {
            get
            {
                return Start.AddMinutes(Duration);
            }
        }

        [JsonIgnore]
        public string HourPresentation
        {
            get
            {
                return string.Format("{0} às {1}", Start.ToString("HH:mm"), End.ToString("HH:mm"));
            }
        }

        [JsonIgnore]
        public string FullDatePresentation
        {
            get
            {
                return string.Format("{0} às {1}", Start.ToString("ddddd, dd/MM/yyyy HH:mm"), End.ToString("HH:mm"));
            }
        }

        [JsonIgnore]
        public string FullPeriodPresentation
        {
            get
            {
                return string.Format("{0} - {1}", Start.ToString("ddddd, dd/MM/yyyy"), PeriodPresentation);
            }
        }

        [JsonIgnore]
        public string PeriodPresentation
        {
            get
            {
                return Start.Hour < 12 ? "Manhã" : "Tarde";
            }
        }

        public string StatusPresentation 
        {
            get
            {
                switch (Status)
                {
                    default: return string.Empty;
                    case AppointmentStatus.Canceled: return "Cancelado";
                    case AppointmentStatus.Completed: return "Completo";
                    case AppointmentStatus.Pending: return "Pendente";
                    case AppointmentStatus.Scheduled: return "Agendado";
                }
            }
        }

        public string AdditionalInfoToString 
        {
            get
            {
                if (AdditionalInfos == null)
                    return string.Empty;

                var msg = string.Empty;

                foreach (var i in AdditionalInfos)
                {
                    msg += string.Format("{0}\n\n", i.TitleWithDescription);
                }

                return msg;
            }
        }

        #endregion

        public enum AppointmentStatus
        {
            None,
            Pending,
            Scheduled,
            Completed,
            Canceled
        }
    }
    //#region OBSOLETE
    //public enum AppointmentStatus
    //{
    //    None,
    //    Pending,
    //    Scheduled,
    //    Completed,
    //    Canceled
    //}

    //public class Appointment : Naylah.Core.Entities.EntityBase
    //{
    //    public Appointment()
    //    {
    //        Period = new DateTimeZonePeriod();
    //        InfoForReturn = new AppointmentInfoForReturn();
    //    }

    //    public AppointmentStatus Status { get; set; }

    //    public DateTimeZonePeriod Period { get; set; }

    //    public string Observations { get; set; }

    //    public AppointmentInfoForReturn InfoForReturn { get; set; }

    //    #region Relations

    //    public string StaffUserId { get; set; }
    //    public Naylah.Core.Entities.Identity.User StaffUser { get; set; }

    //    public string AgendaId { get; set; }

    //    public virtual Agenda Agenda { get; set; }

    //    public virtual ApplicationUser AppUser { get; set; }

    //    public virtual string AppUserId { get; set; }

    //    public virtual string AppUserApplicationId { get; set; }

    //    public virtual DataItem DataItem { get; set; }

    //    public virtual string DataItemId { get; set; }

    //    public virtual DataItem Service { get; set; }

    //    public virtual string ServiceId { get; set; }

    //    public Appointment OriginalAppointment { get; set; }

    //    public string OriginalAppointmentId { get; set; }

    //    #endregion

    //}

    //public class AppointmentInfoForReturn
    //{
    //    public int MaximumDays { get; set; }
    //    public string Observation { get; set; }
    //}

    //#endregion
}
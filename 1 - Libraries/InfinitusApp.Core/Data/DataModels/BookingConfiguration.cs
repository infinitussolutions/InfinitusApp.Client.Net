using InfinitusApp.Core.Data.Commands;
using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class BookingConfiguration : EntityBase
    {
        public BookingConfiguration()
        {
            DataItems = new List<DataItem>();
            HourToCheckIn = new HourSelect();
        }

        public int MinDaysToStart { get; set; }

        public int MaxDaysToStart { get; set; }

        public HourSelect HourToCheckIn { get; set; }

        public int? DurationInMinutesToCheckOut { get; set; }

        public bool HasDurationToCheckOut => DurationInMinutesToCheckOut.HasValue && DurationInMinutesToCheckOut > 0;

        public bool HasNoDurationToCheckOut => !HasDurationToCheckOut;

        public bool HasLimitedToStart => !MinDaysToStart.Equals(0) || !MaxDaysToStart.Equals(0);

        public DateTime FirstDateToStart => HasLimitedToStart ? DateTime.Today.AddDays(MinDaysToStart) : DateTime.Today;

        public DateTime LastDateToStart => HasLimitedToStart ? FirstDateToStart.AddDays(MaxDaysToStart) : DateTime.Today.AddYears(1);

        #region Helper

        public string FirstDateToStartPresentation => HourToCheckIn.HourSelected.HasValue ? MinDaysToStart + " Ex: (" + FirstDateToStart.AddHours(HourToCheckIn.HourSelected.Value).ToString("dd/MM/yy HH:mm") + ")" : "";

        public string LastDateToStartPresentation => HourToCheckIn.HourSelected.HasValue ? MaxDaysToStart + " Ex: (" + LastDateToStart.AddHours(HourToCheckIn.HourSelected.Value).ToString("dd/MM/yy HH:mm") + ")" : "";

        public string DurationBookingPresentation
        {
            get
            {
                var msgReturn = "";

                if (HasNoDurationToCheckOut)
                    return msgReturn;

                var time = new TimeSpan(0, DurationInMinutesToCheckOut.Value, 0);

                if (time.Days > 0)
                {
                    msgReturn += time.Days.Equals(1) ? time.Days + " dia " : time.Days + " dias ";
                }

                else
                {
                    if (time.Hours > 0)
                        msgReturn += time.Hours + " horas ";
                }

                if (time.Minutes > 0)
                    msgReturn += "e " + time.Minutes + " minutos";

                return msgReturn;
            }
        }

        public string Presentation => "MIN dias p/ iniciar: " + MinDaysToStart + " | MAX p/ para iniciar: " + MaxDaysToStart + " | Hrs Início do check-in: " + HourToCheckIn.HourSelected + " | Duração: " + DurationBookingPresentation;

        #endregion

        #region Relations

        public virtual string DataStoreId { get; set; }

        public virtual IList<DataItem> DataItems { get; set; }

        #endregion

        //#region Methods

        //public static BookingConfiguration Create(CreateBookingConfigurationCommand cmd)
        //{
        //    if (!string.IsNullOrEmpty(cmd?.CreateModelValueErrorsMessage))
        //        throw new ArgumentException(cmd.CreateModelValueErrorsMessage);

        //    var modelReturn = new BookingConfiguration
        //    {
        //        DataStoreId = cmd.DataStoreId,
        //        HourToCheckIn = cmd.HourToCheckIn,
        //        DurationInMinutesToCheckOut = cmd.DurationInMinutesToCheckOut,
        //        MaxDaysToStart = cmd.MaxDaysToStart,
        //        MinDaysToStart = cmd.MinDaysToStart
        //    };

        //    modelReturn.GenerateId();

        //    return modelReturn;
        //}

        //#endregion
    }

    public class HourSelect
    {
        public int? HourSelected { get; set; }

        public bool AnyFromOpeningHours => !HourSelected.HasValue;

        public List<HourInfo> HourListForSelect
        {
            get
            {
                return new List<HourInfo>
                {
                    new HourInfo(),
                    new HourInfo{ HourValue = 0},
                    new HourInfo{ HourValue = 1},
                    new HourInfo{ HourValue = 2},
                    new HourInfo{ HourValue = 3},
                    new HourInfo{ HourValue = 4},
                    new HourInfo{ HourValue = 5},
                    new HourInfo{ HourValue = 6},
                    new HourInfo{ HourValue = 7},
                    new HourInfo{ HourValue = 8},
                    new HourInfo{ HourValue = 9},
                    new HourInfo{ HourValue = 10},
                    new HourInfo{ HourValue = 11},
                    new HourInfo{ HourValue = 12},
                    new HourInfo{ HourValue = 13},
                    new HourInfo{ HourValue = 14},
                    new HourInfo{ HourValue = 15},
                    new HourInfo{ HourValue = 16},
                    new HourInfo{ HourValue = 17},
                    new HourInfo{ HourValue = 18},
                    new HourInfo{ HourValue = 19},
                    new HourInfo{ HourValue = 20},
                    new HourInfo{ HourValue = 21},
                    new HourInfo{ HourValue = 22},
                    new HourInfo{ HourValue = 23}
                };
            }
        }
    }

    public class HourInfo
    {
        public int? HourValue { get; set; }

        public string HourDisplay => HourValue.HasValue ? new TimeSpan(HourValue.Value, 0, 0).ToString(@"hh\:mm") : "Qualquer, conforme funcionamento";
    }
}

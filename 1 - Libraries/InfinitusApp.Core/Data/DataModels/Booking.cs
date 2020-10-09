using InfinitusApp.Core.Data.Commands;
using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Booking : EntityBase
    {
        public Booking()
        {
            User = new UserReference();
            Price = new Price();
            BookingExtraInfo = new BookingExtraInfo();
        }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public UserReference User { get; set; }

        public Price Price { get; set; }

        public BookingExtraInfo BookingExtraInfo { get; set; }

        public BookingStatus CurrentStatus { get; set; }

        #region Relations

        public virtual DataItem DataItem { get; set; }

        public virtual string DataItemId { get; set; }

        public virtual Variation Variation { get; set; }

        public virtual string VariationId { get; set; }

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        public virtual FinancialRequest FinancialRequest { get; set; }

        public virtual string FinancialRequestId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual string ApplicationUserId { get; set; }

        #endregion

        [JsonIgnore]
        public bool RequirePayment => Price != null && Price.FinalPrice > 0;

        [JsonIgnore]
        public string Status
        {
            get
            {
                if (string.IsNullOrEmpty(FinancialRequest?.Id))
                    return "Pedido não finalizado";

                return FinancialRequest.FinancialStatusPresentation.Presentation;
            }
        }

        [JsonIgnore]
        public string PeriodPresentation
        {
            get
            {
                return
                    "➡ Check-In: " + CheckInDate.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(CheckInDate.Month) + " " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(CheckInDate.DayOfWeek) + " às " + CheckInDate.ToString("HH:mm") + " hrs\n" +
                    "⬅ Check-Out: " + CheckOutDate.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(CheckOutDate.Month) + " " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(CheckOutDate.DayOfWeek) + " às " + CheckOutDate.ToString("HH:mm") + " hrs";
            }
        }

        [JsonIgnore]
        public string CheckInDatePresentation
        {
            get
            {
                if (CheckInDate.Equals(DateTime.MinValue))
                    return "";

                return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(CheckInDate.DayOfWeek) + "\n" + CheckInDate.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(CheckInDate.Month) + "\nàs " + CheckInDate.ToString("HH:mm") + " hrs";
            }
        }

        [JsonIgnore]
        public string CheckOutDatePresentation
        {
            get
            {
                if (CheckOutDate.Equals(DateTime.MinValue))
                    return "";

                return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(CheckOutDate.DayOfWeek) + "\n" + CheckOutDate.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(CheckOutDate.Month) + "\nàs " + CheckOutDate.ToString("HH:mm") + " hrs";
            }
        }

        [JsonIgnore]
        public string CreatedAtPresentation
        {
            get
            {
                if (!CreatedAt.HasValue)
                    return "";

                return "⏰ Criado em " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(CreatedAt.Value.DayOfWeek) + " " + CreatedAt.Value.ToString("dd") + " de " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(CreatedAt.Value.Month) + " " + CreatedAt.Value.ToString("HH:mm");
            }
        }

        [JsonIgnore]
        public string CurrentStatusPresentation => CurrentStatus.GetPresentation();

        [JsonIgnore]
        public bool CurrentStatusIsOpen => CurrentStatus == BookingStatus.Open;

        [JsonIgnore]
        public bool CurrentStatusIsAccept => CurrentStatus == BookingStatus.Accept;

        [JsonIgnore]
        public bool CurrentStatusIsCanceled => CurrentStatus == BookingStatus.Canceled;

        public List<BookingStatusPresentation> NextPossibleBookingByActual
        {
            get
            {
                var l = new List<BookingStatusPresentation>();

                switch (CurrentStatus)
                {
                    case BookingStatus.Open:
                        l.Add(new BookingStatusPresentation { BookingStatus = BookingStatus.Accept });
                        l.Add(new BookingStatusPresentation { BookingStatus = BookingStatus.Canceled });
                        break;

                    case BookingStatus.Accept:
                        l.Add(new BookingStatusPresentation { BookingStatus = BookingStatus.Canceled });
                        break;
                }

                return l;
            }
        }
    }

    public class BookingExtraInfo
    {
        public int PersonQuantity { get; set; }

        public bool HasExtraInfo => PersonQuantity > 0;
    }

    public enum BookingStatus
    {
        Open,
        Accept,
        Canceled
    }

    public class BookingStatusPresentation
    {
        public BookingStatus BookingStatus { get; set; }

        public string Presentation => BookingStatus.GetPresentation();
    }

    public static class BookingStatusExtention
    {
        public static string GetPresentation(this BookingStatus bookingStatus)
        {
            switch (bookingStatus)
            {
                case BookingStatus.Open:
                    return "Aberto";
                case BookingStatus.Accept:
                    return "Aceito";
                case BookingStatus.Canceled:
                    return "Cancelado";
                default:
                    return "";
            }
        }
    }
}

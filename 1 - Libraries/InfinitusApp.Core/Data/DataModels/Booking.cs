using InfinitusApp.Core.Data.Commands;
using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        #region Relations

        public virtual DataItem DataItem { get; set; }

        public virtual string DataItemId { get; set; }

        public virtual Variation Variation { get; set; }

        public virtual string VariationId { get; set; }

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        public virtual FinancialRequest FinancialRequest { get; set; }

        public virtual string FinancialRequestId { get; set; }

        #endregion

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

        
    }

    public class BookingExtraInfo
    {
        public int PersonQuantity { get; set; }

        public bool HasPersonQuantitiy => PersonQuantity > 0;
    }
}

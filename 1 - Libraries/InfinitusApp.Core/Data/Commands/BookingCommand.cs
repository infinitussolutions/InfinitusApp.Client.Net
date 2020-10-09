using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class BookingCommand
    {
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public string FinancialRequestId { get; set; }

        public BookingExtraInfo BookingExtraInfo { get; set; }

        protected string ModelValueErrorsMessage
        {
            get
            {
                var message = "";

                if (CheckInDate >= CheckOutDate || CheckOutDate <= CheckInDate)
                    message += "InitialDate and FinalDate is not valid\n";

                return message;
            }
        }
    }

    public class CreateBookingCommand : BookingCommand
    {
        public CreateBookingCommand()
        {
            User = new UserReference();
            Price = new Price();
        }

        [Obsolete]
        public UserReference User { get; set; }

        public Price Price { get; set; }

        public string DataItemId { get; set; }

        public string VariationId { get; set; }

        public string DataStoreId { get; set; }
        
        public string CreateModelValueErrorsMessage
        {
            get
            {
                var message = ModelValueErrorsMessage;

                if (string.IsNullOrEmpty(DataStoreId))
                    message += "DataStoreId is not valid\n";

                if (string.IsNullOrEmpty(DataItemId))
                    message += "DataItemId is not valid\n";

                return message;
            }
        }
    }

    public class UpdateBookingCommand : BookingCommand
    {
        public string Id { get; set; }

        public BookingStatus? CurrentStatus { get; set; }
    }

    public class BookingConfigurationCommand
    {
        public BookingConfigurationCommand()
        {
            HourToCheckIn = new HourSelect();
        }

        public int MinDaysToStart { get; set; }

        /// <summary>
        /// From MinDaysToStart, default is 1 year
        /// </summary>
        public int MaxDaysToStart { get; set; }

        public HourSelect HourToCheckIn { get; set; }

        public int? DurationInMinutesToCheckOut { get; set; }

        public bool? AllowMultipleBookingToSameDate { get; set; }
    }

    public class CreateBookingConfigurationCommand : BookingConfigurationCommand
    {
        public string DataStoreId { get; set; }

        //public string CreateModelValueErrorsMessage
        //{
        //    get
        //    {
        //        var message = ModelValueErrorsMessage;

        //        if (string.IsNullOrEmpty(DataStoreId))
        //            message += "DataStoreId is not valid\n";

        //        return message;
        //    }
        //}
    }

    public class UpdateBookingConfigurationCommand : BookingConfigurationCommand
    {
        public string Id { get; set; }
    }
}

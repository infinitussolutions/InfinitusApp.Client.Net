using InfinitusApp.Core.Data.DataModels;
using Naylah.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class DataItemCommand
    {
        public DataItemDescriptionInfo Description { get; set; }

        [Obsolete("Use Visibility")]
        public bool? Visible { get; set; }

        [Obsolete("Use Visibility")]
        public bool? ShowInFeed { get; set; }

        [Obsolete("Use Visibility")]
        public bool? Paused { get; set; }

        public string ScheduleId { get; set; }

        public DataItemIdentificationInfo IdentificationCode { get; set; }

        public MediaImageData MediaImageData { get; set; }

        public OpeningHours OpeningHours { get; set; }

        public VisibilityInfo Visibility { get; set; }

        public DataItemPriceInfo Price { get; set; }

        public DataItemLocationInfo Location { get; set; }

        public DeliveryInfo DeliveryInfo { get; set; }

        public ContactInfo Contact { get; set; }

        public string ApplicationUserId { get; set; }

        public DataItemCompanyInfo Company { get; set; }

        public DataItemBooking Booking { get; set; }
    }

    public class CreateDataItemCommand : DataItemCommand
    {
        public CreateDataItemCommand()
        {
            Price = new DataItemPriceInfo();
            Phones = new List<CreatePhoneCommand>();
        }

        public string DataStoreId { get; set; }

        public string ParentId { get; set; }

        public string Type { get; set; }

        public List<CreatePhoneCommand> Phones { get; set; }
    }

    public class UpdateDataItemCommand : DataItemCommand
    {
        public string Id { get; set; }
    }
}

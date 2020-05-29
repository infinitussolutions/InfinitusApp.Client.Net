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

        [Obsolete("Use Visibility", true)]
        public bool? Visible { get; set; }

        [Obsolete("Use Visibility", true)]
        public bool? ShowInFeed { get; set; }

        [Obsolete("Use Visibility", true)]
        public bool? Paused { get; set; }

        public string ScheduleId { get; set; }

        public DataItemIdentificationInfo IdentificationCode { get; set; }

        public MediaImageData MediaImageData { get; set; }

        public OpeningHours OpeningHours { get; set; }

        public VisibilityInfo Visibility { get; set; }

        public DataItemPriceInfo Price { get; set; }

    }

    public class CreateDataItemCommand : DataItemCommand
    {
        public CreateDataItemCommand()
        {
            CompanyInfo = new CreateDataItemCompanyInfo();
            Price = new DataItemPriceInfo();
            Phones = new List<CreatePhoneCommand>();
        }

        public CreateDataItemCompanyInfo CompanyInfo { get; set; }

        public string DataStoreId { get; set; }

        public string ParentId { get; set; }

        public string Type { get; set; }

        public string ApplicationUserId { get; set; }

        public List<CreatePhoneCommand> Phones { get; set; }
    }

    public class UpdateDataItemCommand : DataItemCommand
    {
        public string Id { get; set; }
    }

    public class CreateDataItemCompanyInfo
    {
        public string DocumentNumber { get; set; }
    }

}

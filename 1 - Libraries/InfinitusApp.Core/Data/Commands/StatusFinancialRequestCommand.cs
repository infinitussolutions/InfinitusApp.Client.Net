using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class StatusFinancialRequestCommand
    {
        public string Title { get; set; }

        public StatusActionsFinancialRequest Action { get; set; }

        public StatusFinancialRequestConfig Config { get; set; }
    }

    public class CreateStatusFinancialRequestCommand : StatusFinancialRequestCommand
    {
        public string DataStoreId { get; set; }
    }

    public class UpdateStatusFinancialRequestCommand : StatusFinancialRequestCommand
    {
        public string Id { get; set; }
    }

    public class FinancialRequestStatusRelationCommand
    {
        public string Message { get; set; }
    }

    public class CreateFinancialRequestStatusRelationCommand : FinancialRequestStatusRelationCommand
    {
        public string FinancialRequestId { get; set; }

        public string StatusFinancialRequestId { get; set; }
    }
}

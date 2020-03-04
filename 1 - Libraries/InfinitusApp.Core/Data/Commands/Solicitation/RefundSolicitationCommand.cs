using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Solicitation
{
    public class RefundSolicitationCommand : SolicitationCommand
    {

    }

    public class RefundSolicitationCreateCommand : RefundSolicitationCommand
    {
        public string ApplicationUserId { get; set; }
        public string FinancialRequestId { get; set; }
        public string DataStoreId { get; set; }
    }

    public class RefundSolicitationUpdateCommand : RefundSolicitationCommand
    {
        public string Id { get; set; }
    }
}

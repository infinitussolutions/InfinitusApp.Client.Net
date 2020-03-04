using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Solicitation : EntityBase
    {
        public Solicitation()
        {

        }

        public string Description { get; set; }
        public string Comment { get; set; }
        public SolicitationStatus Status { get; set; }

        #region Relations

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public DataStore DataStore { get; set; }
        public string DataStoreId { get; set; }

        #endregion

        public enum SolicitationStatus
        {
            Pending,
            Approved,
            Refused
        }
    }

    public class RefundSolicitation : Solicitation
    {
        public RefundSolicitation()
        {

        }

        #region Relations

        public FinancialRequest FinancialRequest { get; set; }
        public string FinancialRequestId { get; set; }

        #endregion
    }
}

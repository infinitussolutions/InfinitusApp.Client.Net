using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ExternalConnection : EntityBase
    {
        public ExternalConnection()
        {

        }

        public string ReferenceId { get; set; }

        public ExternalConnectionType Type { get; set; }

        #region Relations

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        #endregion

        public enum ExternalConnectionType
        {
            Unknown,
            IuguCustomer
        }

    }
}

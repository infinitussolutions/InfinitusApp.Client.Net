using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class CustomerZone : Naylah.Core.Entities.EntityBase
    {
        public CustomerZone()
        {
            Customers = new List<Customer>();
            ApplicationUsers = new List<ApplicationUser>();
        }

        public string Name { get; set; }
        public string InitialZipCode { get; set; }
        public string FinalZipCode { get; set; }

        #region Relations

        public IList<Customer> Customers { get; set; }
        public IList<ApplicationUser> ApplicationUsers { get; set; }
        public string DataStoreId { get; set; }

        #endregion
    }
}

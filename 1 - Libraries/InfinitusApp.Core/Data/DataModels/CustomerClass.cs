using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class CustomerClass : EntityBase
    {
        public CustomerClass()
        {

        }

        public string Description { get; set; }

        public string ExternalCode { get; set; }

        public IList<Customer> Customers { get; set; }

        public string DataStoreId { get; set; }

        public string DescriptionPresentation
        {
            get
            {
                return string.Format("Tipo: {0}", string.IsNullOrWhiteSpace(Description) ? "Não informado" : Description);
            }
        }
    }
}

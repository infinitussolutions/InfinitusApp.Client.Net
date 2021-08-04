using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class CustomerType : EntityBase
    {
        public CustomerType()
        {
            Customers = new List<Customer>();

        }

        public string Description { get; set; }

        public IList<Customer> Customers { get; set; }

        public string DataStoreId { get; set; }

        public string DescriptionPresentation 
        {
            get
            {
                return string.Format("Tipo Fiscal: {0}", string.IsNullOrWhiteSpace(Description) ? "Não informado" : Description);
            }
        }
    }
}

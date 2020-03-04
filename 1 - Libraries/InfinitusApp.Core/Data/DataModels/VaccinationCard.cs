using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class VaccinationCard : EntityBase
    {
        public VaccinationCard()
        {

        }

        public string VaccineName { get; set; }
        public decimal? AnimalWeight { get; set; }
        public decimal? Dose { get; set; }
        public string Responsible { get; set; }
        public string Observation { get; set; }
        public DateTime? NextDate { get; set; }

        #region Relations
        public DataItem DataItem { get; set; }
        public string DataItemId { get; set; }
        #endregion
    }
}

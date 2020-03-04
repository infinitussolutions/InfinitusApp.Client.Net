using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class VaccinationCardCommand
    {
        public string VaccineName { get; set; }
        public decimal? AnimalWeight { get; set; }
        public decimal? Dose { get; set; }
        public string Responsible { get; set; }
        public string Observation { get; set; }
        public DateTime? NextDate { get; set; }
    }

    public class CreateVaccinationCardCommand : VaccinationCardCommand
    {
        public string DataItemId { get; set; }
    }

    public class UpdateVaccinationCardCommand : VaccinationCardCommand
    {
        public string Id { get; set; }
    }
}

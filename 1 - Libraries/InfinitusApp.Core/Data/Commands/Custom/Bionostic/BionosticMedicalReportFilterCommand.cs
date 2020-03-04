using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Services.Custom.Bionostic.Models.BionosticResponsibleContact;

namespace InfinitusApp.Core.Data.Commands.Custom.Bionostic
{
    public class BionosticMedicalReportFilterCommand
    {
        public BionosticResponsibleType ResponsibleType { get; set; }
        /// <summary>
        /// Responsible Or Clinic ID
        /// </summary>
        public string TargetId { get; set; }
        public string ResponsibleName { get; set; }
        public string PetName { get; set; }
        public int Start { get; set; }
        public int Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public enum TaxRegimeTypes
    {
        SimpleNational = 1,
        SimpleNationalExcess = 2,
        Normal = 3
    }

    public class LegalEntityInfo
    {
        public LegalEntityInfo()
        {
            TaxRegime = TaxRegimeTypes.Normal;
        }

        public string StateRegistration { get; set; }

        public string MunicipalRegistration { get; set; }

        public TaxRegimeTypes TaxRegime { get; set; }
    }
}

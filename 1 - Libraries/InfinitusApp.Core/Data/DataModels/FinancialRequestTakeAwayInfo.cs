using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialRequestTakeAwayInfo
    {
        public DateTime? DateToTake { get; set; }

        public string DateToTakePresentation => DateToTake.HasValue ? DateToTake.Value.ToString("dd/MM/yy") : "";
    }
}

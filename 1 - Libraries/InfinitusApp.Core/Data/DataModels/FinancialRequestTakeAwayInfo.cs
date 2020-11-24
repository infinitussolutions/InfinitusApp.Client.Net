using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialRequestTakeAwayInfo
    {
        public DateTime? DateToTake { get; set; }

        public bool HasDateToTake => DateToTake.HasValue;

        public string DateToTakePresentation => HasDateToTake ? DateToTake.Value.ToString("dd/MMM/yy - ddd") + " ás " + DateToTake.Value.ToString("HH:mm") : "O mais breve possível";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class IdentificationCode
    {
        public string Letter { get; set; }

        public int Number { get; set; }

        public string LetterAndNumberPresentation
        {
            get
            {
                var _number = Number != 0 ? Number.ToString() : string.Empty;

                return Letter?.ToUpper() + _number;
            }
        }
    }
}

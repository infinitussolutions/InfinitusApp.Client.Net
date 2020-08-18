using System;

namespace InfinitusApp.Core.Data.DataModels
{
    [Obsolete("Use Phone Model")]
    public class PhoneComplex
    {
        public string IDD { get; set; }

        public string DDD { get; set; }

        public string PhoneNumber { get; set; }

        public string FullPhone
        {
            get
            {
                if (string.IsNullOrEmpty(PhoneNumber))
                    return "";

                return string.Format("+{0}({1}){2}", IDD, DDD, PhoneNumber);
            }
        }

        public bool IsValid => !string.IsNullOrEmpty(DDD) && !string.IsNullOrEmpty(PhoneNumber);
    }
}
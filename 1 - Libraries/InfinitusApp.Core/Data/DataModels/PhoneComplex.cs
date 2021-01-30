using System;

namespace InfinitusApp.Core.Data.DataModels
{
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

                var phone = string.Empty;

                if (!string.IsNullOrEmpty(IDD))
                    phone += string.Format("+{0}", IDD.Replace("+", ""));

                if (!string.IsNullOrEmpty(DDD))
                    phone += string.Format(" ({0})", DDD.Replace(" ", ""));

                phone += string.Format(" {0}", PhoneNumber);

                return phone;
               // return string.Format("+{0} ({1}) {2}", IDD, DDD, PhoneNumber);
            }
        }

        public string FullNumberToWhatsApp => (FullPhone.Contains("55") ? FullPhone : "55" + FullPhone).Replace(" ", "").Replace("+", "").Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "");

        public bool IsValid => !string.IsNullOrEmpty(DDD) && !string.IsNullOrEmpty(PhoneNumber);

        public string PhonePresentation 
        {
            get
            {
                return string.Format("Fone: {0}", FullPhone);
            }
        }
    }
}
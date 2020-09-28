using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Extensions
{
    public static class DayOfWeekExtention
    {
        public static string GetPresentation(this DayOfWeek dayOfWeek, bool isSimple = false)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return isSimple ? "Dom" : "Domingo";
                case DayOfWeek.Monday:
                    return isSimple ? "Seg" : "Segunda-Feira";
                case DayOfWeek.Tuesday:
                    return isSimple ? "Ter" : "Terça-Feira";
                case DayOfWeek.Wednesday:
                    return isSimple ? "Qua" : "Quarta-Feira";
                case DayOfWeek.Thursday:
                    return isSimple ? "Qui" : "Quinta-Feira";
                case DayOfWeek.Friday:
                    return isSimple ? "Sex" : "Sexta-Feira";
                case DayOfWeek.Saturday:
                    return isSimple ? "Sáb" : "Sábado";
            }

            return "";
        }
    }
}

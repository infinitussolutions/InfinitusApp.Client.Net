using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Extensions
{
    public static class MathExtention
    {
        public static decimal CalculatePercentage(decimal initialValue, decimal percentage)
        {
            return (initialValue * percentage) / 100;
        }

        public static decimal RoundToUp(this decimal value)
        {
            return Math.Ceiling(value);
        }

        public static decimal RoundToDown(this decimal value)
        {
            return Math.Floor(value);
        }
    }
}

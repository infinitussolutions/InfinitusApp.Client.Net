using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Extensions
{
    public static class EnumExtention
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}

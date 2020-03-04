using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Extensions
{
    public static class ColorExtention
    {
        /// <summary>
        /// From https://flatuicolors.com/palette/defo
        /// </summary>
        public static List<string> HexFlatColors
        {
            get
            {
                return new List<string>
                {
                    "#16a085",
                    "#2980b9",
                    "#8e44ad",
                    "#2c3e50",
                    "#1abc9c",
                    "#3498db",
                    "#9b59b6",
                    "#34495e",
                };
            }
        }

        public static string GetARandomHexFlatColor { get { return HexFlatColors.PickRandom(); } }
    }
}

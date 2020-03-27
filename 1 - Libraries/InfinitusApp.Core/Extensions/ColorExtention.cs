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
                    "#27ae60",
                    "#2980b9",
                    "#8e44ad",
                    "#2c3e50",
                    "#f39c12",
                    "#d35400",
                    "#c0392b",
                };
            }
        }

        public static string GetARandomHexFlatColor()
        {
            return HexFlatColors.PickRandom();
        }
    }
}

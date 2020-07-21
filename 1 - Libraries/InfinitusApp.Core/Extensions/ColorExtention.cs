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

        public static List<PrimaryAndDarkColor> PrimaryAndDarkColors
        {
            get
            {
                return new List<PrimaryAndDarkColor>
                {
                    new PrimaryAndDarkColor
                    {
                        PrimaryDark = "#C2185B",
                        Primary = "#E91E63"
                    },
                    new PrimaryAndDarkColor
                    {
                        PrimaryDark = "#00796B",
                        Primary ="#009688"
                    },
                    new PrimaryAndDarkColor
                    {
                        PrimaryDark = "#7B1FA2",
                        Primary = "#9C27B0"
                    },
                    new PrimaryAndDarkColor
                    {
                        PrimaryDark = "#1976D2",
                        Primary = "#2196F3"
                    },
                    new PrimaryAndDarkColor
                    {
                        PrimaryDark = "#388E3C",
                        Primary = "#4CAF50"
                    },
                    new PrimaryAndDarkColor
                    {
                        PrimaryDark = "#512DA8",
                        Primary = "#673AB7"
                    }
                };
            }
        }

        public static string GetARandomHexFlatColor()
        {
            return HexFlatColors.PickRandom();
        }

        public static PrimaryAndDarkColor GetARandomPrimaryAndDarkColor()
        {
            return PrimaryAndDarkColors.PickRandom();
        }
    }

    public class PrimaryAndDarkColor
    {
        public string Primary { get; set; }

        public string PrimaryDark { get; set; }
    }
}

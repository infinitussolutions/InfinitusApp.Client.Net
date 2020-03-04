using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FontIcon
    {
        public FontIcon()
        {
            FontInfo = new FontInfo();
        }

        public FontIcon(FontIcon icon)
        {
            Source = icon.Source;
            FontInfo = icon.FontInfo;
        }

        public string Source { get; set; }

        public FontInfo FontInfo { get; set; }
    }

    public class FontInfo
    {
        public FontNameType Name { get; set; }

        public FontType Type { get; set; }
    }

    public enum FontNameType
    {
        Awesome,
        OpenSans
    }

    public enum FontType
    {
        Bold,
        BoldItalic,
        ExtraBold,
        ExtraBoldItalic,
        Italic,
        Light,
        LightItalic,
        Regular,
        SemiBold,
        SemiBoldItalic,
        Solid,
        Brand
    }
}

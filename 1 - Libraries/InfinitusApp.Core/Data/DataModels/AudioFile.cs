using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class AudioFile
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public Stream Stream { get; set; }
    }
}

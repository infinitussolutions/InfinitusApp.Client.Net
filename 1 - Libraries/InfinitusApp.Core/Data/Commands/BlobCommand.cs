using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class BlobCommand
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public MemoryStream Stream { get; set; }
        public BlobContainerName Container { get; set; }

        public enum BlobContainerName
        {
            doc,
            img,
            temp
        }
    }
}

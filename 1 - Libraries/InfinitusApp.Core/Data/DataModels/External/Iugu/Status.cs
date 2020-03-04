using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Iugu
{
    public class Status
    {
        public Status()
        {

        }

        public string _type { get; set; }
        public int missing { get; set; }
        public int total { get; set; }
        public int other { get; set; }
        public List<Term> terms { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Bank
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public bool IsDeleted { get; set; }

        public string CodeWithName 
        {
            get
            {
                return string.Format("{0} - {1}", Code, Name);
            }
        }
    }
}

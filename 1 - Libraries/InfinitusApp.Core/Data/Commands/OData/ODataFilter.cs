using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.OData
{
    public class ODataFilter
    {
        public ODataFilter()
        {
            Skip = 0;
            Top = 10;
        }

        public int Skip { get; set; }
        public int Top { get; set; }
    }
}

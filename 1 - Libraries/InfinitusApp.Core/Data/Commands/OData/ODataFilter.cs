using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.OData
{
    public class ODataFilter
    {
        public int Skip { get; set; }
        public int Top { get; set; }
    }
}

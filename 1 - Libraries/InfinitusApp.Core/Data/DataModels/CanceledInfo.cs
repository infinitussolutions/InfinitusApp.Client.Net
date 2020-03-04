﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class CanceledInfo
    {
        public bool IsCanceled { get; set; }

        public string Motive { get; set; }

        public string UserId { get; set; }

        public DateTimeOffset? CanceledIn { get; set; }
    }
}

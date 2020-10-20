using GalaSoft.MvvmLight;
using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Shared
{
    public class ModelObservableBase : ObservableObject, IEntityBase
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public bool Deleted { get; set; }

        public string Id { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public string Version { get; set; }
    }
}

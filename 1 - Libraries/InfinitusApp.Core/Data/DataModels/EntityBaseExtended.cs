using GalaSoft.MvvmLight;
using System;

namespace InfinitusApp.Core.Data.DataModels
{
    public class EntityBaseExtended : ObservableObject, Naylah.Core.Entities.IEntityBase
    {
        private string _id;

        public virtual string Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private string _version;

        //[Version]
        public virtual string Version
        {
            get { return _version; }
            set { Set(ref _version, value); }
        }

        private DateTimeOffset? _createdAt;

        //[CreatedAt]
        public DateTimeOffset? CreatedAt
        {
            get { return _createdAt; }
            set { Set(ref _createdAt, value); }
        }

        private DateTimeOffset? _updatedAt;

        //[UpdatedAt]
        public DateTimeOffset? UpdatedAt
        {
            get { return _updatedAt; }
            set { Set(ref _updatedAt, value); }
        }

        private bool _deleted;

        //[Deleted]
        public bool Deleted
        {
            get { return _deleted; }
            set { Set(ref _deleted, value); }
        }
    }
}
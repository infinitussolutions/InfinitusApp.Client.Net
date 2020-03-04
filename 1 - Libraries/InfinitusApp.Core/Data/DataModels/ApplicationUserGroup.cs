﻿using System.Collections.Generic;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ApplicationUserGroup : Naylah.Core.Entities.EntityBase
    {
        public ApplicationUserGroup()
        {
            Users = new List<ApplicationUser>();
        }

        public string Name { get; set; }

        public string ApplicationId { get; set; }

        public IList<ApplicationUser> Users { get; set; }

        public bool AllowAutoInvitation { get; set; }

        public bool ForbiddenDelete { get; set; }
    }
}
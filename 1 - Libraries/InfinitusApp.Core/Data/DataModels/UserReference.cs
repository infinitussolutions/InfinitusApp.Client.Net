using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class UserReference
    {
        public UserReference()
        {
            UserApplicationInfo = new CreatedByApplicationInfo();
            UserPlataformInfo = new CreatedByPlatformInfo();
            ClientType = UserReferenceType.Undefined;
        }

        public UserReferenceType ClientType { get; set; }

        public CreatedByApplicationInfo UserApplicationInfo { get; set; }

        public CreatedByPlatformInfo UserPlataformInfo { get; set; }

        #region Helps

        public string UserId
        {
            get
            {
                return ClientType == UserReferenceType.Application ?
                    UserApplicationInfo?.ApplicationUserId :
                    UserPlataformInfo?.UserId;
            }
        }

        public string UserName
        {
            get
            {
                return ClientType == UserReferenceType.Application ?
                    UserApplicationInfo?.AppUser?.FullName :
                    UserPlataformInfo?.User?.FullName;
            }
        }

        #endregion
    }

    public class CreatedByApplicationInfo
    {
        public string ApplicationUserId { get; set; }

        public string ApplicationId { get; set; }
        public ApplicationUser AppUser { get; set; }
    }

    public class CreatedByPlatformInfo
    {
        public string UserId { get; set; }

        public string CompanyId { get; set; }
        public Naylah.Core.Entities.Identity.User User { get; set; }
    }

    public enum UserReferenceType
    {
        Undefined,
        Application,
        Platform
    }


}

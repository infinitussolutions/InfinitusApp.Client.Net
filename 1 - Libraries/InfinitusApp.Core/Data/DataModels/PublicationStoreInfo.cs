using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class PublicationStoreInfo
    {
        public AndroidInfo Android { get; set; }

        public IosInfo Ios { get; set; }

        public WindowsInfo Windows { get; set; }
    }

    public class AndroidInfo : PlatformPublicationBase
    {
    }

    public class IosInfo : PlatformPublicationBase
    {
    }

    public class WindowsInfo : PlatformPublicationBase
    {
    }

    public class PlatformPublicationBase
    {
        public string Link { get; set; }
    }
}

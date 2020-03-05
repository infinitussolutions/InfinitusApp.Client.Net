using InfinitusApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    public class _0___TestBase
    {
        public InfinitusAppServiceClient Client
        {
            get
            {
                return InfinitusAppServiceClient.Create(InfinitusAppServiceAccess.EnvironmentsTypes.Dev, "bf08946f-292b-4851-882a-f2f908abe53a", "wlx9sNEGoEOSqVmDz16g", "");
            }
        }
    }
}

using System;

namespace InfinitusApp.Services
{
    public partial class InfinitusAppServiceAccess
    {
        public static Uri InfinitusAppServiceCustomUri = new Uri("https://infinitus-custom.azurewebsites.net/infinitusapp/");

        public enum EnvironmentsTypes
        {
            Custom,
            Dev,
            Test,
            Stag,
            Prod
        }

        public static Uri InfinitusAppServiceDevUri => new Uri("https://infinitus-dev.azurewebsites.net/infinitusapp/");
        public static Uri InfinitusAppServiceTestUri => new Uri("https://infinitus-test.azurewebsites.net/infinitusapp/");
        public static Uri InfinitusAppServiceStagUri => new Uri("https://infinitus-stag.azurewebsites.net/infinitusapp/");
        public static Uri InfinitusAppServiceProdUri => new Uri("https://infinitus.azurewebsites.net/infinitusapp/");

        public static Uri GetServiceAccessUri(EnvironmentsTypes type)
        {
            switch (type)
            {
                case EnvironmentsTypes.Dev:
                    return InfinitusAppServiceDevUri;

                case EnvironmentsTypes.Test:
                    return InfinitusAppServiceTestUri;

                case EnvironmentsTypes.Stag:
                    return InfinitusAppServiceStagUri;

                case EnvironmentsTypes.Prod:
                    return InfinitusAppServiceProdUri;

                default:
                    return InfinitusAppServiceCustomUri;
            }
        }
    }
}
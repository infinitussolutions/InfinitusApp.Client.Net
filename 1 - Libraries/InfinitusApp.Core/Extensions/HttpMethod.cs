namespace InfinitusApp.Core.Extensions
{
    public class HttpMethod : System.Net.Http.HttpMethod
    {
        public HttpMethod(string method)
            : base(method)
        {
        }

        public static System.Net.Http.HttpMethod Patch { get { return new System.Net.Http.HttpMethod("PATCH"); } }
    }
}
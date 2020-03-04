//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace InfinitusApp.Services._2___Extention.Cached
//{
//    public class ServiceClientCached : ServiceBase
//    {
//        public ServiceClientCached(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
//        {
//        }

//        public async Task<T> Get<T>(string apiName, IDictionary<string, string> parameters, TimeSpan expiredIn, bool forceReflesh = false)
//        {
//            var cachedInfo = await apiName.GetCached<T>(parameters, forceReflesh);

//            if (cachedInfo.HasObjectInCached)
//                return cachedInfo.ObjectInCached;

//            return await cachedInfo.SetCached(await ServiceClient.InvokeApiAsync<T>(apiName, HttpMethod.Get, parameters), expiredIn);
//        }
//    }
//}

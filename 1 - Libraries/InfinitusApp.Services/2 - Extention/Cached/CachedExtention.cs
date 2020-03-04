//using Plugin.Connectivity;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace InfinitusApp.Services._2___Extention.Cached
//{
//    public static class CachedExtention
//    {
//        public static async Task<CachedInfo<T>> GetCached<T>(this string apiName, IDictionary<string, string> parameters, bool forceReflesh = false)
//        {
//            return await Task.Run(() =>
//            {
//                var objReturn = new CachedInfo<T>
//                {
//                    Key = apiName
//                };

//                if (parameters != null && parameters.Count > 0)
//                {
//                    objReturn.Key += "/";

//                    foreach (var item in parameters)
//                    {
//                        objReturn.Key += item.Key + "=" + item.Value;
//                    }
//                }

//                objReturn.Key = objReturn.Key.Replace(" ", "");

//                if (forceReflesh)
//                    objReturn.Empty();

//                if (!CrossConnectivity.Current.IsConnected)
//                    objReturn.ObjectInCached = Barrel.Current.Get<T>(key: objReturn.Key);

//                if (!Barrel.Current.IsExpired(key: objReturn.Key))
//                    objReturn.ObjectInCached = Barrel.Current.Get<T>(key: objReturn.Key);

//                objReturn.ApiName = apiName;

//                return objReturn;
//            });
//        }
        
//        public static void EmptyAll()
//        {
//            Barrel.Current.EmptyAll();
//        }

//        public static void EmptyExpired()
//        {
//            Barrel.Current.EmptyExpired();
//        }

//    }

//    public class CachedInfo<T>
//    {
//        public string ApiName { get; set; }

//        public string Key { get; set; }

//        public T ObjectInCached { get; set; }

//        public bool HasObjectInCached { get { return ObjectInCached != null; } }

//        public async Task<T> SetCached(T data, TimeSpan expireIn)
//        {
//            return await Task.Run(async () =>
//            {
//                Barrel.Current.Add(key: Key, data: data, expireIn: expireIn);
//                return data;
//            });
//        }

//        public DateTime? GetExpiration()
//        {
//            return Barrel.Current.GetExpiration(Key);
//        }

//        public void Empty()
//        {
//            Barrel.Current.Empty(new string[] { Key });
//        }
//    }
//}

using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Encryption
{
    public class EncryptionService : ServiceBase
    {
        private const string EncryptionKey = "2Beh49hew7Ape^iP148.WsX[,W<feH-:";
        public EncryptionService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<string> Encrypt(string content)
        {
            try
            {
                if (string.IsNullOrEmpty(content))
                    throw new Exception("Content is null");

                var dic = new Dictionary<string, string>
                {
                    { "content", content }
                };

                return await ServiceClient.InvokeApiAsync<string>("Encryption/Encrypt", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Decrypt(string content)
        {
            try
            {
                if (string.IsNullOrEmpty(content))
                    throw new Exception("Content is null");

                var dic = new Dictionary<string, string>
                {
                    { "content", content },
                    { "key", EncryptionKey }
                };

                return await ServiceClient.InvokeApiAsync<string>("Encryption/Decrypt", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.Signature;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Signature
{
    public class SignaturePlanApplicationUserService : ServiceBase
    {
        public SignaturePlanApplicationUserService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<SignaturePlanApplicationUser> Create(CreateSignaturePlanApplicationUserCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateSignaturePlanApplicationUserCommand, SignaturePlanApplicationUser>("SignaturePlanApplicationUser/Create", createCommand);
        }

        public async Task<List<SignaturePlanApplicationUser>> GetAll()
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlanApplicationUser>>("SignaturePlanApplicationUser/GetAll", HttpMethod.Get, null);
        }
    }
}

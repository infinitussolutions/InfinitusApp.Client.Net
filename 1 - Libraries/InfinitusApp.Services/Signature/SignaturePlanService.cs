using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.Signature;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Signature
{
    public class SignaturePlanService : ServiceBase
    {
        public SignaturePlanService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<SignaturePlan> Create(CreateSignaturePlanCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateSignaturePlanCommand, SignaturePlan>("SignaturePlan/Create", createCommand);
        }

        public async Task<SignaturePlan> Update(UpdateSignaturePlanCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<UpdateSignaturePlanCommand, SignaturePlan>("SignaturePlan/Update", createCommand, HttpMethod.Patch, null);
        }

        public async Task<List<SignaturePlan>> GetAll()
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlan>>("SignaturePlan/GetAll", HttpMethod.Get, null);
        }
    }
}

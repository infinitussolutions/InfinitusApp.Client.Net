using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.AdditionalInfos
{
    public class AdditionalInfoService : ServiceBase
    {
        public AdditionalInfoService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<AdditionalInfo> Create(AdditionalInfoCreateCommand cmd)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<AdditionalInfoCreateCommand, AdditionalInfo>("AdditionalInfo/Create", cmd);
        }

        public async Task<List<AdditionalInfo>> CreateList(List<AdditionalInfoCreateCommand> cmd)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<AdditionalInfoCreateCommand>, List<AdditionalInfo>>("AdditionalInfo/CreateList", cmd);
        }
    }
}

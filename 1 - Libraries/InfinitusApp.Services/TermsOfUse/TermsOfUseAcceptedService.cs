using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.TermsOfUse
{
    public class TermsOfUseAcceptedService : ServiceBase
    {
        public TermsOfUseAcceptedService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<TermsOfUseAccepted> Create(TermsOfUseAcceptedCreateCommand command)
        {
            return await ServiceClient.InvokeApiAsync<TermsOfUseAcceptedCreateCommand, TermsOfUseAccepted>("TermsOfUseAccepted/Create", command);
        }

        public async Task<TermsOfUseAccepted> Update(TermsOfUseAcceptedUpdateCommand command)
        {
            return await ServiceClient.InvokeApiAsync<TermsOfUseAcceptedUpdateCommand, TermsOfUseAccepted>("TermsOfUseAccepted/Update", command, HttpMethod.Patch, null);
        }

        public async Task<List<TermsOfUseAccepted>> GetAllByApplicationUserId(string appUserId)
        {
            var dic = new Dictionary<string, string>()
                {
                    { "appUserId", appUserId },
                };

            return await ServiceClient.InvokeApiAsync<List<TermsOfUseAccepted>>("TermsOfUseAccepted/GetAllByApplicationUserId", HttpMethod.Get, dic);
        }
    }
}

using InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu;
using InfinitusApp.Core.Data.DataModels.External.Iugu;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Iugu
{
    public class IuguAccountService : ServiceBase
    {
        public IuguAccountService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<IuguAccount> Create(IuguCreateAccountCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<IuguCreateAccountCommand, IuguAccount>("Iugu/Account/Create", cmd, HttpMethod.Post, null);
        }

        public async Task<IuguAccountInfo> Configure(IuguAccountConfigurationCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<IuguAccountConfigurationCommand, IuguAccountInfo>("Iugu/Account/Configure", cmd, HttpMethod.Post, null);
        }

        public async Task<IuguValidateAccountCommand> Validate(IuguValidateAccountCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<IuguValidateAccountCommand, IuguValidateAccountCommand>("Iugu/Account/Validate", cmd, HttpMethod.Post, null);
        }

        public async Task<IuguWithdrawResponse> RequestWithdraw(IuguRequestWithdrawCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<IuguRequestWithdrawCommand, IuguWithdrawResponse>("Iugu/Account/RequestWithdraw", cmd, HttpMethod.Post, null);
        }

        public async Task<IuguAccountInfo> GetByMarketplaceId(string marketplaceId)
        {
            var dic = new Dictionary<string, string>
            {
                { "marketplaceId", marketplaceId }
            };

            return await ServiceClient.InvokeApiAsync<IuguAccountInfo>("Iugu/Account/GetByMarketplaceId", HttpMethod.Get, dic);
        }
    }
}

using InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu;
using InfinitusApp.Core.Data.DataModels.External.Iugu;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Iugu
{
    public class IuguCustomerService : ServiceBase
    {
        public IuguCustomerService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<IuguCustomerModel> CreateWithPaymentCreditCard(IuguCustomerCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<IuguCustomerCommand, IuguCustomerModel>("Iugu/Customer/Create", cmd, HttpMethod.Post, null);
        }
    }
}

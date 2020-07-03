using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Bank
{
    public class BankService : ServiceBase
    {
        public BankService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<Core.Data.DataModels.Bank>> GetAll()
        {
            var banks = await ServiceClient.MobileServiceClient.InvokeApiAsync<List<Core.Data.DataModels.Bank>>("Bank/GetAll", HttpMethod.Get, null);

            return banks?.Where(x => !x.IsDeleted)?.ToList();
        }
    }
}

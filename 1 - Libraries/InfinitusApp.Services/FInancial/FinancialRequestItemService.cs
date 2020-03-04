using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.FInancial
{
    public class FinancialRequestItemService : ServiceBase
    {
        public FinancialRequestItemService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<IList<FinancialRequestItem>> GetAllByDataItemId(string dataItemId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId }
            };

            return await ServiceClient.InvokeApiAsync<IList<FinancialRequestItem>>("FinancialRequestItem/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task<IList<FinancialRequestItem>> UpdateList(IList<UpdateFinancialRequestItemCommand> updateCommand)
        {
            return await ServiceClient.InvokeApiAsync<IList<UpdateFinancialRequestItemCommand>, IList<FinancialRequestItem>>("FinancialRequestItem/UpdateList", updateCommand, HttpMethod.Patch, null);
        }
    }
}

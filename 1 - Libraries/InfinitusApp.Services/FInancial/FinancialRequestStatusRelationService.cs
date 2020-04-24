using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.FInancial
{
    public class FinancialRequestStatusRelationService : ServiceBase
    {
        public FinancialRequestStatusRelationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<FinancialRequestStatusRelation> Create(CreateFinancialRequestStatusRelationCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateFinancialRequestStatusRelationCommand, FinancialRequestStatusRelation>("FinancialRequestStatusRelation/Create", createCommand);
        }
    }
}

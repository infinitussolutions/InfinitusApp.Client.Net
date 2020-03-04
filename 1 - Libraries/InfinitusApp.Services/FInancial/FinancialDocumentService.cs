using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.FInancial
{
    public class FinancialDocumentService : ServiceBase
    {
        public FinancialDocumentService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<FinancialDocument> Create(CreateFinancialDocumentCommand createCommand)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(createCommand);

            return await ServiceClient.InvokeApiAsync<CreateFinancialDocumentCommand, FinancialDocument>("FinancialDocument/Create", createCommand);
        }

        public async Task<FinancialDocument> GetById(string Id, bool includeExternalModel = false)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", Id },
                {"includeExternalModel", includeExternalModel.ToString() }
            };

            return await ServiceClient.InvokeApiAsync<FinancialDocument>("FinancialDocument/GetById", HttpMethod.Get, dic);
        }
    }
}

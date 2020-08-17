using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static InfinitusApp.Core.Data.DataModels.ExternalConnection;

namespace InfinitusApp.Services.CreditCard
{
    public class CreditCardInfoService : ServiceBase
    {
        public CreditCardInfoService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<CreditCardInfo> CreateToCurrentApplicationUser(CreateCreditCardInfoCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateCreditCardInfoCommand, CreditCardInfo>("CreditCardInfo/CreateToCurrentApplicationUser", cmd, HttpMethod.Post, null);
        }

        public async Task<CreditCardValidResponse> IsCreditCartValid(CreateCreditCardInfoCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateCreditCardInfoCommand, CreditCardValidResponse>("CreditCardInfo/IsCreditCartValid", cmd, HttpMethod.Post, null);
        }

        public async Task<List<CreditCardInfo>> GetAllByCurrentApplicationUser(Expression<Func<CreditCardInfo, bool>> entityFilter = null, Expression<Func<CreditCardInfo, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false, ExternalConnectionType? externalConnectionType = null)
        {
            var odataBuilder = new ODataQueryBuilder<CreditCardInfo>("")
                    .For<CreditCardInfo>(x => x)
                    .ByList();

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
            {
                if (desc)
                    odataBuilder.OrderByDescending(entityOrderBy);

                else
                    odataBuilder.OrderBy(entityOrderBy);
            }

            var dic = odataBuilder.ToDictionary();

            if (externalConnectionType.HasValue)
                dic.Add("externalConnectionType", externalConnectionType.Value.ToString());

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<CreditCardInfo>>("CreditCardInfo/GetAllByCurrentApplicationUser", HttpMethod.Get, dic);
        }

        public async Task<CreditCardInfo> Update(SetAProblemCreditCardInfoCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<SetAProblemCreditCardInfoCommand, CreditCardInfo>("CreditCardInfo/SetAProblem", cmd, HttpMethod.Patch, null);
        }

        public async Task<bool> ChangeCreditCardDefault(string toCreditCardId)
        {
            var dic = new Dictionary<string, string>
            {
                {"toCreditCardId", toCreditCardId }
            };

            return await ServiceClient.InvokeApiAsync<bool>("CreditCardInfo/ChangeCreditCardDefault", HttpMethod.Patch, dic);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("CreditCardInfo/Delete", HttpMethod.Delete, dic);
        }
    }
}

using InfinitusApp.Core.Data.DataModels.Voucher;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Voucher
{
    public class VoucherGenerateService : ServiceBase
    {
        public VoucherGenerateService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<VoucherGenerate>> GetAll(Expression<Func<VoucherGenerate, bool>> entityFilter = null, Expression<Func<VoucherGenerate, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<VoucherGenerate>("")
                    .For<VoucherGenerate>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<VoucherGenerate>>(nameof(VoucherGenerate) + "/GetAll", HttpMethod.Get, dic);
        }

        public async Task<VoucherGenerate> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id",id }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<VoucherGenerate>(nameof(VoucherGenerate) + "/GetById", HttpMethod.Get, dic);
        }

        public async Task<VoucherGenerate> SetUsedByCurrentApplicationUser(string voucherCode)
        {
            var dic = new Dictionary<string, string>
            {
                {"voucherCode",voucherCode }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<VoucherGenerate>(nameof(VoucherGenerate) + "/SetUsedByCurrentApplicationUser", HttpMethod.Patch, dic);
        }
    }
}

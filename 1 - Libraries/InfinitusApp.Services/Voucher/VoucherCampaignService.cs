using InfinitusApp.Core.Data.Commands;
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
    public class VoucherCampaignService : ServiceBase
    {
        public VoucherCampaignService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<VoucherCampaign> Create(CreateSignaturePlanCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateSignaturePlanCommand, VoucherCampaign>(nameof(VoucherCampaign) + "/Create", createCommand);
        }

        public async Task<VoucherCampaign> Update(UpdateSignaturePlanCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<UpdateSignaturePlanCommand, VoucherCampaign>(nameof(VoucherCampaign) + "/Update", createCommand, HttpMethod.Patch, null);
        }

        public async Task<List<VoucherCampaign>> GetAll(Expression<Func<VoucherCampaign, bool>> entityFilter = null, Expression<Func<VoucherCampaign, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<VoucherCampaign>("")
                    .For<VoucherCampaign>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<VoucherCampaign>>(nameof(VoucherCampaign) + "/GetAll", HttpMethod.Get, dic);
        }

        public async Task<VoucherCampaign> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id",id }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<VoucherCampaign>(nameof(VoucherCampaign) + "/GetById", HttpMethod.Get, dic);
        }
    }
}

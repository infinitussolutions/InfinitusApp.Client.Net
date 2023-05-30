using InfinitusApp.Core.Data.Commands.Custom.DrPeanut;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Custom.DrPeanut
{
    public class DrPeanutService : ServiceBase
    {
        public DrPeanutService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<DrPeanutReturnFinancialRequest> GetDiscount(DrPeanutFinancialRequestCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<DrPeanutFinancialRequestCommand, DrPeanutReturnFinancialRequest>("Custom/DrPeanut/DrPeanut/GetDiscount", cmd);
        }

        public async Task<bool> CreateRequest(DrPeanutCreateFinancialRequestCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<DrPeanutCreateFinancialRequestCommand, bool>("Custom/DrPeanut/DrPeanut/CreateRequest", cmd);
        }

        public async Task<bool> CreateCustomer(DrPeanutCustomerCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<DrPeanutCustomerCommand, bool>("Custom/DrPeanut/DrPeanut/CreateCustomer", cmd);
        }

        public async Task<List<DrPeanutGetDiscountResponse>> GetDiscountRange(DrPeanutGetDiscountCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<DrPeanutGetDiscountCommand, List<DrPeanutGetDiscountResponse>>("Custom/DrPeanut/DrPeanut/GetDiscountRange", cmd);
        }

        public async Task<List<DrPeanutGetICSMResponseCommand>> GetICMSST(DrPeanutGetICSMRequestCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<DrPeanutGetICSMRequestCommand, List<DrPeanutGetICSMResponseCommand>>("Custom/DrPeanut/DrPeanut/GetICMS", cmd);
        }

        public async Task<List<DrPeanutRequestsPendingApprovalResponseCommand>> GetRequestsPendingApproval(DrPeanutRequestsPendingApprovalCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<DrPeanutRequestsPendingApprovalCommand, List<DrPeanutRequestsPendingApprovalResponseCommand>>("Custom/DrPeanut/DrPeanut/GetRequestsPendingApproval", cmd);
        }
    }
}

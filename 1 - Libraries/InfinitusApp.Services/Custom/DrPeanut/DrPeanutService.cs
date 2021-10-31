using InfinitusApp.Core.Data.Commands.Custom.DrPeanut;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<DrPeanutGetDiscountResponse> GetDiscountRange(DrPeanutGetDiscountCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<DrPeanutGetDiscountCommand, DrPeanutGetDiscountResponse>("Custom/DrPeanut/DrPeanut/GetDiscountRange", cmd);
        }
    }
}

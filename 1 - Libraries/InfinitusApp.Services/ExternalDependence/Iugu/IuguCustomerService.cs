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

        public async Task<IuguCustomerModel> CreateCustomer(IuguCustomerCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<IuguCustomerCommand, IuguCustomerModel>("Iugu/Customer/Create", cmd, HttpMethod.Post, null);
        }

        #region Payment Method

        public async Task<PaymentMethodModel> CreatePaymentMethod(CreateIuguPaymentMethodCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateIuguPaymentMethodCommand, PaymentMethodModel>("Iugu/Customer/CreatePaymentMethod", cmd, HttpMethod.Post, null);
        }

        public async Task<PaymentMethodModel> DeletePaymentMethod(DeleteIuguPaymentMethodCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<DeleteIuguPaymentMethodCommand, PaymentMethodModel>("Iugu/Customer/DeletePaymentMethod", cmd, HttpMethod.Delete, null);
        }

        public async Task<PaymentMethodModel> UpdatePaymentMethod(UpdateIuguPaymentMethodCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateIuguPaymentMethodCommand, PaymentMethodModel>("Iugu/Customer/UpdatePaymentMethod", cmd, HttpMethod.Put, null);
        }

        public async Task<List<PaymentMethodModel>> GetAllByApplicationUserId(string appUserId)
        {
            var dic = new Dictionary<string, string>
            {
                { "appUserId", appUserId }
            };

            return await ServiceClient.InvokeApiAsync<List<PaymentMethodModel>>("Iugu/Customer/GetAllByApplicationUserId", HttpMethod.Get, dic);
        }

        #endregion
    }
}

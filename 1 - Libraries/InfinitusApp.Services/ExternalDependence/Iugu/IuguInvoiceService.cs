using InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Data.DataModels.External.Iugu;
using InfinitusApp.Core.Extensions;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Iugu
{
    public class IuguInvoiceService : ServiceBase
    {
        public IuguInvoiceService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        //public async Task<IuguInvoice> CreateWithPaymentCreditCard(CreateWithCreditCardCommand cmd)
        //{
        //    return await ServiceClient.InvokeApiAsync<CreateWithCreditCardCommand, IuguInvoice>("Iugu/Invoice/CreateWithPaymentCreditCard", cmd, HttpMethod.Post, null);
        //}

        //public async Task<IuguInvoice> CreateWithPaymentBankSlip(CreateWithBankSlipCommand cmd)
        //{
        //    return await ServiceClient.InvokeApiAsync<CreateWithBankSlipCommand, IuguInvoice>("Iugu/Invoice/CreateWithPaymentBankSlip", cmd, HttpMethod.Post, null);
        //}
        public async Task<IuguInvoice> GetInvoiceById(string dataStoreId, string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"dataStoreId", dataStoreId },
                {"id", id }
            };
            return await ServiceClient.InvokeApiAsync<IuguInvoice>("Iugu/Invoice/GetById", HttpMethod.Get, dic);

        }
    }
}

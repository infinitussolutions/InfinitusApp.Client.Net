using InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu;
using InfinitusApp.Core.Data.DataModels.External.Iugu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Iugu
{
    public class IuguPayService : ServiceBase
    {
        public IuguPayService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<ChargeResponseMessage> PayInvoiceWithCreditCard(PayWithCreditCardCommand command)
        {
            return await ServiceClient.InvokeApiAsync<PayWithCreditCardCommand, ChargeResponseMessage>("Iugu/Pay/PayInvoiceWithCreditCard", command);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using InfinitusApp.Core.Data.Commands.ExternalDependence.Twilio;

namespace InfinitusApp.Services.ExternalDependence.Twilio
{
    public class TwilioService : ServiceBase
    {
        public TwilioService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<string> VerifyNumber(CreateTwilioVerifyNumberSMSCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateTwilioVerifyNumberSMSCommand, string>("Twilio/VerifyNumber", cmd);
        }
    }
}

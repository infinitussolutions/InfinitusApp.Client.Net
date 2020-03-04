using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Email
{
    public class EmailService : ServiceBase
    {
        public EmailService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<bool> SendEventCreatedConfirmation(SendEventCreatedConfirmationCommand command)
        {
            return await ServiceClient.InvokeApiAsync<SendEventCreatedConfirmationCommand, bool>("Email/SendEventCreateConfirmation", command, HttpMethod.Post, null);
        }

        public async Task<bool> SendInvitedApp(SendInvitedAppCommand command)
        {
            return await ServiceClient.InvokeApiAsync<SendInvitedAppCommand, bool>("Email/SendInvitedApp", command, HttpMethod.Post, null);
        }

        public async Task<bool> SendInvitedEvent(SendInvitedEventCommand command)
        {
            return await ServiceClient.InvokeApiAsync<SendInvitedAppCommand, bool>("Email/SendInvitedEvent", command, HttpMethod.Post, null);
        }
    }
}

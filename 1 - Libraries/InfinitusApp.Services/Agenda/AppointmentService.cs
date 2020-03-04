using InfinitusApp.Core.Data.Commands.Agenda;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Agenda
{
    public class AppointmentService : ServiceBase
    {
        public AppointmentService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<Appointment> CreateAppointment(AppointmentCreateCommand cmd)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<AppointmentCreateCommand, Appointment>("Agenda/Appointment/Create", cmd);
        }

        public async Task<Appointment> Update(AppointmentUpdateCommand cmd)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<AppointmentUpdateCommand, Appointment>("Agenda/Appointment/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<List<Appointment>> GetAllByUser(UserReference user)
        {
            return await ServiceClient.MobileServiceClient.InvokeApiAsync<UserReference, List<Appointment>>("Agenda/Appointment/GetAllByUser", user);
        }


        public async Task<List<Appointment>> GetAllByDataItemId(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", id }
            };

            return await ServiceClient.InvokeApiAsync<List<Appointment>>("Agenda/Appointment/GetAllByDataItemId", HttpMethod.Get, dic);
        }

        public async Task<List<Appointment>> GetAllByDataStoreId(string dataStoreId, string filter = "")
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId },
            };

            if (!string.IsNullOrEmpty(filter))
                dic.Add("$filter", filter);

            return await ServiceClient.InvokeApiAsync<List<Appointment>>("Agenda/Appointment/GetAllByDataStoreId", HttpMethod.Get, dic);
        }
    }
}

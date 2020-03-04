using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Agenda
{
    public class ScheduleResponsibleService : ServiceBase
    {
        public ScheduleResponsibleService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<List<ScheduleResponsible>> GetAllByScheduleConfig(string scheduleConfigId)
        {
            var dic = new Dictionary<string, string>
            {
                { "scheduleConfigId", scheduleConfigId }
            };

            return await ServiceClient.InvokeApiAsync<List<ScheduleResponsible>>("Agenda/ScheduleResponsible/GetAllByScheduleConfig", HttpMethod.Get, dic);
        }
    }
}

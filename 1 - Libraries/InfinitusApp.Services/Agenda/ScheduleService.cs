using InfinitusApp.Core.Data.Commands.Agenda;
using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Agenda
{
    public class ScheduleService : ServiceBase
    {
        public ScheduleService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Schedule> Create(ScheduleCreateCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<ScheduleCreateCommand, Schedule>("Schedule/Create", createCommand);
        }

        public async Task<List<Schedule>> GetAllByDadaStoreId(string datastoreId, bool includeConfig = false)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", datastoreId },
                {"includeConfig", includeConfig.ToString() }
            };

            return await ServiceClient.InvokeApiAsync<List<Schedule>>("Schedule/GetAllByDataStoreId", HttpMethod.Get, dic);
        }

        public async Task<Schedule> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id },
            };

            return await ServiceClient.InvokeApiAsync<Schedule>("Schedule/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<TimeZoneInfo>> GetSystemTimeZones()
        {
            return await ServiceClient.InvokeApiAsync<List<TimeZoneInfo>>("Schedule/GetSystemTimeZones", HttpMethod.Get, null);
        }
    }
}

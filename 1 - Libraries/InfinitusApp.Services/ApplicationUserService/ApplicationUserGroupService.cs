using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ApplicationUserService
{
    public class ApplicationUserGroupService : ServiceBase
    {
        public ApplicationUserGroupService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<ApplicationUserGroup>> GetAllByApplicationId(string appId)
        {
            var dic = new Dictionary<string, string>
                {
                    { "applicationId", appId }
                };

            return await ServiceClient.InvokeApiAsync<List<ApplicationUserGroup>>("ApplicationUserGroup/GetAllByApplicationId", HttpMethod.Get, dic);
        }

        public async Task<ApplicationUserGroup> AddUserToGroup(ApplicationUserGroupManageCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<ApplicationUserGroupManageCommand, ApplicationUserGroup>("ApplicationUserGroup/AddUsers", cmd);
        }

        public async Task<bool> AddUsersInMultipleGroups(ApplicationUserGroupManageCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<ApplicationUserGroupManageCommand, bool>("ApplicationUserGroup/AddUsersInMultipleGroups", cmd);
        }

        public async Task<ApplicationUserGroup> AddDataItemToGroup(ApplicationUserGroupManageCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<ApplicationUserGroupManageCommand, ApplicationUserGroup>("ApplicationUserGroup/AddDataItem", cmd);
        }
    }
}

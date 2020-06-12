using InfinitusApp.Core.Data.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using static InfinitusApp.Core.Data.Enums.DataItemEnums;

namespace InfinitusApp.Services.Address
{
    public class AddressService : ServiceBase
    {
        public AddressService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Core.Data.DataModels.Address> Create(CreateAddressCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CreateAddressCommand, Core.Data.DataModels.Address>("Address/Create", cmd);
        }

        public async Task<Core.Data.DataModels.Address> Update(UpdateAddressCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateAddressCommand, Core.Data.DataModels.Address>("Address/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<List<DataItemAddressResult>> GetAllDataItemByLocation(string dataStoreId, double latitude, double longitude, string dtItemType = "", string groupId = "", int skip = 0, int top = 10, string tagId = "", string q = "")
        {
            var dic = new Dictionary<string, string>
            {
                { "dataStoreId", dataStoreId },
                { "$skip", skip.ToString() },
                { "$top", top.ToString() },
                {"latitude",latitude.ToString().Replace(",",".") },
                {"longitude",longitude.ToString().Replace(",",".") }
            };

            if (!string.IsNullOrEmpty(dtItemType))
                dic.Add("dataItemType", dtItemType.ToString());

            if (!string.IsNullOrEmpty(groupId))
                dic.Add("groupId", groupId.ToString());

            if (!string.IsNullOrEmpty(tagId))
                dic.Add("tagId", tagId);

            if (!string.IsNullOrEmpty(q))
                dic.Add("q", q);

            //return await ServiceClient.InvokeApiAsync<List<DataItemAddressResult>>("Address/GetAllDataItemByLocation", HttpMethod.Get, dic);

            return await ServiceClient.InvokeApiAsync<List<DataItemAddressResult>>("Address/GetAllDataItemByLocation", HttpMethod.Get, dic);
        }

        public async Task<Core.Data.DataModels.Address> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<Core.Data.DataModels.Address>("Address/GetById", HttpMethod.Get, dic);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("Address/Delete", HttpMethod.Delete, dic);
        }

        public async Task<IList<Core.Data.DataModels.Address>> GetAllByApplicationUserId(string applicationUserId)
        {
            var dic = new Dictionary<string, string>
            {
                { "applicationUserId", applicationUserId }
            };

            return await ServiceClient.InvokeApiAsync<IList<Core.Data.DataModels.Address>>("Address/GetAllByApplicationUserId", HttpMethod.Get, dic);
        }

        public async Task<int> GetAllByApplicationUserIdCount(string applicationUserId)
        {
            var dic = new Dictionary<string, string>
            {
                { "applicationUserId", applicationUserId }
            };

            return await ServiceClient.InvokeApiAsync<int>("Address/GetAllByApplicationUserIdCount", HttpMethod.Get, dic);
        }
    }

    public class DataItemAddressResult
    {
        public DataItemAddressResult()
        {
            DataItem = new Core.Data.DataModels.DataItem();
            Schedule = new Schedule();
        }

        public Core.Data.DataModels.DataItem DataItem { get; set; }

        public double Distance { get; set; }

        public Schedule Schedule { get; set; }

        public string DataItemType { get; set; }

        public string DataItemGroupId { get; set; }

        public bool InOperating { get; set; }

        public bool DeviveryToDistance { get; set; }
    }
}

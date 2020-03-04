using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.DataStore
{
    public class VaccinationCardService : ServiceBase
    {
        public VaccinationCardService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<VaccinationCard>> GetAllByDataItemId(string id)
        {
            try
            {
                var dic = new Dictionary<string, string>();
                dic.Add("dataItemId", id);

                return await ServiceClient.InvokeApiAsync<List<VaccinationCard>>("VacinnationCard/GetAllByDataItemId", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<VaccinationCard> Create(CreateVaccinationCardCommand cmd)
        {
            try
            {
                return await ServiceClient.MobileServiceClient.InvokeApiAsync<CreateVaccinationCardCommand, VaccinationCard>("VacinnationCard/Create", cmd);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<VaccinationCard> Update(UpdateVaccinationCardCommand cmd)
        {
            try
            {
                return await ServiceClient.MobileServiceClient.InvokeApiAsync<UpdateVaccinationCardCommand, VaccinationCard>("VacinnationCard/Update", cmd, HttpMethod.Patch, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var dic = new Dictionary<string, string>
            {
                { "id", id }
            };
                return await ServiceClient.MobileServiceClient.InvokeApiAsync<bool>("VacinnationCard/Delete", HttpMethod.Delete, dic);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

using InfinitusApp.Core.Data.DataModels.External.Location;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.ExternalDependence.Location
{
    public class LocationService : ServiceBase
    {
        public LocationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<ViaCepResponse> GetAdressByPostalCode(string postalCode)
        {
            var dic = new Dictionary<string, string>
                {
                    { "postalCode", postalCode }
                };

            return await ServiceClient.InvokeApiAsync<ViaCepResponse>("External/Location/GetAdressByPostalCode", HttpMethod.Get, dic);
        }

        public async Task<List<IbgeStateProvince>> GetStateProvinces()
        {
            return await ServiceClient.InvokeApiAsync<List<IbgeStateProvince>>("External/Location/GetStateProvinces", HttpMethod.Get, null);
        }
    }
}

using InfinitusApp.Core.Data.Commands.Solicitation;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Solicitation
{
    public class RefundSolicitationService : ServiceBase
    {
        public RefundSolicitationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<RefundSolicitation> Create(RefundSolicitationCreateCommand command)
        {
            try
            {
                return await ServiceClient.InvokeApiAsync<RefundSolicitationCreateCommand, RefundSolicitation>("Solicitation/RefundSolicitation/Create", command);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<RefundSolicitation> Update(RefundSolicitationUpdateCommand command)
        {
            try
            {
                return await ServiceClient.InvokeApiAsync<RefundSolicitationUpdateCommand, RefundSolicitation>("Solicitation/RefundSolicitation/Update", command, HttpMethod.Patch, null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<RefundSolicitation>> GetAllByDataStoreId(string dataStoreId)
        {
            try
            {
                var dic = new Dictionary<string, string>()
                {
                    { "appUserId", dataStoreId },
                };

                return await ServiceClient.InvokeApiAsync<List<RefundSolicitation>>("Solicitation/RefundSolicitation/GetAllByDataStoreId", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<RefundSolicitation>> GetAllByDataStoreIdWithRelations(string dataStoreId)
        {
            try
            {
                var dic = new Dictionary<string, string>()
                {
                    { "appUserId", dataStoreId },
                };

                return await ServiceClient.InvokeApiAsync<List<RefundSolicitation>>("Solicitation/RefundSolicitation/GetAllByDataStoreIdWithRelations", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<RefundSolicitation> GetByFinancialRequestId(string requestId)
        {
            try
            {
                var dic = new Dictionary<string, string>()
                {
                    { "requestId", requestId },
                };

                return await ServiceClient.InvokeApiAsync<RefundSolicitation>("Solicitation/RefundSolicitation/GetByFinancialRequestId", HttpMethod.Get, dic);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

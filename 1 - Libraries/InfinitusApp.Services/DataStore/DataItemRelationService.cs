using InfinitusApp.Core.Data.Commands.DataItem;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.DataStore
{
    public class DataItemRelationService : ServiceBase
    {
        public DataItemRelationService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<DataItemRelation> Create(CreateDataItemRelationCommand command)
        {
            return await ServiceClient.InvokeApiAsync<CreateDataItemRelationCommand, DataItemRelation>("DataItemRelation/Create", command, HttpMethod.Post, null);
        }

        public async Task<DataItemRelation> Update(UpdateDataItemRelationCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<UpdateDataItemRelationCommand, DataItemRelation>("DataItemRelation/Update", cmd, HttpMethod.Patch, null);
        }

        public async Task<bool> Delete(string id)
        {
            var dic = new Dictionary<string, string>
            {
                {"id", id }
            };

            return await ServiceClient.InvokeApiAsync<bool>("DataItemRelation/Delete", HttpMethod.Delete, dic);
        }

        public async Task<DataItemRelation> GetDataItemById(string id)
        {
            var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

            return await ServiceClient.InvokeApiAsync<DataItemRelation>("DataItemRelation/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<DataItemRelation>> GetAllByDataItemFromId(string dataitemFromId, Expression<Func<DataItemRelation, bool>> entityFilter = null, Expression<Func<DataItemRelation, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<DataItemRelation>("")
                    .For<DataItemRelation>(x => x)
                    .ByList();

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
            {
                if (desc)
                    odataBuilder.OrderByDescending(entityOrderBy);

                else
                    odataBuilder.OrderBy(entityOrderBy);
            }

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataitemFromId", dataitemFromId);

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<DataItemRelation>>("DataItemRelation/GetAllByDataItemFromId", HttpMethod.Get, dic);
        }

        public async Task<List<DataItemRelation>> GetAllByDataItemToId(string dataitemToId, Expression<Func<DataItemRelation, bool>> entityFilter = null, Expression<Func<DataItemRelation, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<DataItemRelation>("")
                    .For<DataItemRelation>(x => x)
                    .ByList();

            if (top.HasValue)
                odataBuilder.Top(top.Value);

            if (skip.HasValue)
                odataBuilder.Skip(skip.Value);

            if (entityFilter != null)
                odataBuilder.Filter(entityFilter);

            if (entityOrderBy != null)
            {
                if (desc)
                    odataBuilder.OrderByDescending(entityOrderBy);

                else
                    odataBuilder.OrderBy(entityOrderBy);
            }

            var dic = odataBuilder.ToDictionary();

            dic.Add("dataitemToId", dataitemToId);

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<DataItemRelation>>("DataItemRelation/GetAllByDataItemToId", HttpMethod.Get, dic);
        }

    }
}

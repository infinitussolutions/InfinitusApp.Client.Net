﻿using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.Signature;
using InfinitusApp.Core.Extensions;
using OData.QueryBuilder.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static InfinitusApp.Core.Data.Enums.DataItemEnums;

namespace InfinitusApp.Services.Signature
{
    public class SignaturePlanApplicationUserService : ServiceBase
    {
        public SignaturePlanApplicationUserService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<SignaturePlanApplicationUser> Create(CreateSignaturePlanApplicationUserCommand createCommand)
        {
            return await ServiceClient.InvokeApiAsync<CreateSignaturePlanApplicationUserCommand, SignaturePlanApplicationUser>("SignaturePlanApplicationUser/Create", createCommand);
        }

        public async Task<SignaturePlanApplicationUser> Update(UpdateSignaturePlanApplicationUserCommand updateCommand)
        {
            return await ServiceClient.InvokeApiAsync<UpdateSignaturePlanApplicationUserCommand, SignaturePlanApplicationUser>("SignaturePlanApplicationUser/Update", updateCommand, HttpMethod.Patch, null);
        }

        public async Task<bool> Cancel(CanceledInfoCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<CanceledInfoCommand, bool>("SignaturePlanApplicationUser/Cancel", cmd, HttpMethod.Patch, null);
        }

        public async Task<List<SignaturePlanApplicationUser>> GetAll(Expression<Func<SignaturePlanApplicationUser, bool>> entityFilter = null, Expression<Func<SignaturePlanApplicationUser, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<SignaturePlanApplicationUser>("")
                    .For<SignaturePlanApplicationUser>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlanApplicationUser>>("SignaturePlanApplicationUser/GetAll", HttpMethod.Get, dic);
        }

        public async Task<List<SignaturePlanApplicationUser>> GetAllByCurrentUser(Expression<Func<SignaturePlanApplicationUser, bool>> entityFilter = null, Expression<Func<SignaturePlanApplicationUser, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<SignaturePlanApplicationUser>("")
                    .For<SignaturePlanApplicationUser>(x => x)
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

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlanApplicationUser>>("SignaturePlanApplicationUser/GetAllByCurrentUser", HttpMethod.Get, dic);
        }

        public async Task<SignaturePlanApplicationUser> HasActiveSignatureByDataItemAndSolutionId(string id, Expression<Func<SignaturePlanApplicationUser, bool>> entityFilter = null, Expression<Func<SignaturePlanApplicationUser, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<SignaturePlanApplicationUser>("")
                    .For<SignaturePlanApplicationUser>(x => x)
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
            dic.Add("id", id);

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<SignaturePlanApplicationUser>("SignaturePlanApplicationUser/GetById", HttpMethod.Get, dic);
        }

        public async Task<bool> HasActiveSignatureByDataItemAndSolutionId(string dataItemId, string solutionId)
        {
            var dic = new Dictionary<string, string>
            {
                { "dataItemId", dataItemId },
                { "solutionId", solutionId }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<bool>("SignaturePlanApplicationUser/HasActiveSignatureByDataItemAndSolutionId", HttpMethod.Get, dic);
        }

        public async Task<SignaturePlanApplicationUser> GetById(string id)
        {
            var dic = new Dictionary<string, string>
            {
                { "id", id }
            };

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<SignaturePlanApplicationUser>("SignaturePlanApplicationUser/GetById", HttpMethod.Get, dic);
        }

        public async Task<List<SignaturePlanApplicationUser>> GetAllBySignaturePlanId(string signaturePlanId, Expression<Func<SignaturePlanApplicationUser, bool>> entityFilter = null, Expression<Func<SignaturePlanApplicationUser, object>> entityOrderBy = null, int? skip = null, int? top = null, bool desc = false)
        {
            var odataBuilder = new ODataQueryBuilder<SignaturePlanApplicationUser>("")
                    .For<SignaturePlanApplicationUser>(x => x)
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
            dic.Add("signaturePlanId", signaturePlanId);

            return await ServiceClient.MobileServiceClient.InvokeApiAsync<List<SignaturePlanApplicationUser>>("SignaturePlanApplicationUser/GetAllBySignaturePlanId", HttpMethod.Get, dic);
        }
    }
}

using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services._1___Interfaces
{
    public interface ISubscriptionSolutionService
    {
        Task<List<SubscriptionSolutionApp>> GetAllByCompanyId(string companyId);
    }
}

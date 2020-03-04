using InfinitusApp.Core.Data.DataModels;
using Naylah.Services.Client;

namespace InfinitusApp.Services.Account
{
    public class Account
    {
        public ApplicationUser User { get; set; }

        public NaylahServiceUser ServiceUser { get; set; }
    }
}
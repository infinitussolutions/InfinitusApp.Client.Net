using InfinitusApp.Core.Data.DataModels.Signature;
using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class CreditCardInfo : EntityBase
    {
        public CreditCardInfo()
        {
            SignaturePlanApplicationUsers = new List<SignaturePlanApplicationUser>();
        }

        public string MaskedNumber { get; set; }

        public string Token { get; set; }

        /// <summary>
        /// Master Card, Visa e etc...
        /// </summary>
        public string Type { get; set; }

        public string ProblemDescription { get; set; }

        #region Relations

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual string ApplicationUserId { get; set; }

        public virtual IList<SignaturePlanApplicationUser> SignaturePlanApplicationUsers { get; set; }

        #endregion

        #region Help

        public bool HasAProblem { get { return !string.IsNullOrEmpty(ProblemDescription); } }

        public string TypeAndMasked { get { return "(" + Type + ") " + MaskedNumber; } }

        #endregion
    }

    public class CreditCardValidResponse
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }
    }
}

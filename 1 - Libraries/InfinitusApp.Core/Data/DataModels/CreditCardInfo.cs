using InfinitusApp.Core.Data.DataModels.Signature;
using InfinitusApp.Core.Extensions;
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

        //public PrimaryAndDarkColor PrimaryAndDarkColor => ColorExtention.GetARandomPrimaryAndDarkColor();

        //public string HexPrimaryDarkColor { get; set; }

        //public string HexPrimaryColor { get; set; }

        public PrimaryAndDarkColor PrimaryAndDarkColor => ColorExtention.GetARandomPrimaryAndDarkColor();

        public string IconFromType => Type.GetLogo();

        #endregion
    }

    public class CreditCardValidResponse
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }
    }

    public static class CreditCartInfoExtention
    {
        public static string GetLogo(this string cardType)
        {
            switch (cardType)
            {
                case "mastercard":
                    return "\uf1f1";
                case "visa":
                    return "\uf1f0";
                case "americanexpress":
                    return "\uf1f3";
                case "discover":
                    return "\uf1f2";
                case "jcb":
                    return "\uf24b";
            }

            return "";
        }
    }
}

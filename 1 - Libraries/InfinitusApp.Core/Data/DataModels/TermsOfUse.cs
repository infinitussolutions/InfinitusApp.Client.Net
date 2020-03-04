using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InfinitusApp.Core.Data.DataModels
{
    public class TermsOfUse
    {
        public TermsOfUse()
        {
            LastUpdate = DateTimeOffset.Now;
        }

        public string Terms { get; set; }

        public string UrlTerms { get; set; }

        public DateTimeOffset LastUpdate { get; set; }

        #region Helpers

        [JsonIgnore]
        public string TitleInTerms
        {
            get
            {
                if (IsWebSite)
                    return string.Empty;

                var text = "";

                var startTag = "[title]";
                var endTag = "[/title]";

                if (Terms.Trim().Contains(startTag))
                {
                    int startIndex = Terms.IndexOf(startTag) + startTag.Length;
                    int endIndex = Terms.IndexOf(endTag, startIndex);
                    text = Terms.Substring(startIndex, endIndex - startIndex);
                }

                return text;

            }
        }

        [JsonIgnore]
        public string AnimationInTerms
        {
            get
            {
                if (IsWebSite)
                    return string.Empty;

                var text = "";

                var startTag = "[lottie]";
                var endTag = "[/lottie]";

                if (Terms.Trim().Contains(startTag))
                {
                    int startIndex = Terms.IndexOf(startTag) + startTag.Length;
                    int endIndex = Terms.IndexOf(endTag, startIndex);
                    text = Terms.Substring(startIndex, endIndex - startIndex);
                }

                else
                    text = "lottie_signature.json";

                return text;
            }
        }

        [JsonIgnore]
        public bool HasTerms
        {
            get
            {
                return !string.IsNullOrEmpty(Terms) || !string.IsNullOrEmpty(UrlTerms);
            }
        }

        public bool IsWebSite
        {
            get
            {
                return !string.IsNullOrEmpty(UrlTerms);
            }
        }

        #endregion
    }

    public class TermsOfUseAccepted : EntityBase
    {
        public TermsOfUseAccepted()
        {

        }

        public string ReferencyId { get; set; }

        public TypeTerm ReferencyType { get; set; }

        public DateTimeOffset Date { get; set; }

        #region Relations

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        #endregion

        public enum TypeTerm
        {
            Application,
            PersonalizedAppMenu,
            Structure
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class SocialMedia
    {
        public SocialMedia()
        {
            Instagram = new Instagram();
            Facebook = new Facebook();
            Twitter = new Twitter();
            Linkedin = new Linkedin();
        }

        public Instagram Instagram { get; set; }

        public Facebook Facebook { get; set; }

        public Twitter Twitter { get; set; }

        public Linkedin Linkedin { get; set; }
    }

    public class SocialMediaInfoBase
    {
        public string Uri { get; set; }
    }

    public class Instagram : SocialMediaInfoBase
    {
        public string UriPresentation { get { return string.IsNullOrEmpty(Uri) ? "" : "https://www.instagram.com/" + Uri; } }
    }

    public class Facebook : SocialMediaInfoBase
    {
        public string UriPresentation { get { return string.IsNullOrEmpty(Uri) ? "" : "https://www.facebook.com/" + Uri; } }
    }

    public class Twitter : SocialMediaInfoBase
    {
        public string UriPresentation { get { return string.IsNullOrEmpty(Uri) ? "" : "https://twitter.com/" + Uri; } }
    }

    public class Linkedin : SocialMediaInfoBase
    {
        public string UriPresentation { get { return string.IsNullOrEmpty(Uri) ? "" : "https://www.linkedin.com/in/" + Uri; } }
    }
}

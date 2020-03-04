using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.TermsOfUseAccepted;

namespace InfinitusApp.Core.Data.Commands
{
    public class TermsOfUseAcceptedCommand
    {
        public DateTimeOffset Date { get; set; }
    }

    public class TermsOfUseAcceptedCreateCommand : TermsOfUseAcceptedCommand
    {
        public string ReferencyId { get; set; }
        public TypeTerm ReferencyType { get; set; }
        public string ApplicationUserId { get; set; }
    }

    public class TermsOfUseAcceptedUpdateCommand : TermsOfUseAcceptedCommand
    {
        public string Id { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands.Custom.Bionostic
{
    public class BionosticPasswordCommand
    {
        public string OldPassword { get; set; } = string.Empty;
    }

    public class BionosticResponsiblePasswordCommand : BionosticPasswordCommand
    {
        [JsonProperty("resp_id")]
        public string ResponsibleId { get; set; }
        [JsonProperty("resp_senha")]
        public string NewPassword { get; set; } = string.Empty;
    }

    public class BionosticClinicPasswordCommand : BionosticPasswordCommand
    {
        [JsonProperty("clin_id")]
        public string ClinicId { get; set; }
        [JsonProperty("clin_senha")]
        public string NewPassword { get; set; } = string.Empty;
    }

    public class BionosticPasswordModel
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string NewPasswordConfirmation { get; set; } = string.Empty;
    }

}

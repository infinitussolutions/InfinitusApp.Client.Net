using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class CanceledInfoCommand
    {
        /// <summary>
        /// Id from model to set canceled
        /// </summary>
        public string Id { get; set; }

        public string Motive { get; set; }

        public string UserId { get; set; }

        /// <summary>
        /// Set future date to schedule canceled
        /// </summary>
        public DateTimeOffset CanceledIn { get; set; } = DateTimeOffset.UtcNow.Date;

        public string ValidatedModelMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Id))
                    msg += nameof(Id) + " is not valid\n";

                if (string.IsNullOrEmpty(UserId))
                    msg += nameof(UserId) + " is not valid\n";

                return msg;
            }
        }
    }
}

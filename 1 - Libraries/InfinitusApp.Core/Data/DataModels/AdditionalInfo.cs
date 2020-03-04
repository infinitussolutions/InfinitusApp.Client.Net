using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class AdditionalInfo : EntityBase
    {
        public AdditionalInfo()
        {

        }

        public string Title { get; set; }
        public string Description { get; set; }

        #region Relations

       // public Appointment Appointment { get; set; }

        public string AppointmentId { get; set; }

        #endregion

        public string TitleWithDescription 
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                    return Description;

                return string.Format("{0}: {1}", Title, Description);
            }
        }
    }
}

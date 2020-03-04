using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    public class BionosticResponseLogin
    {
        public bool Authenticated { get; set; }

        public BionosticClinic Clinic { get; set; }

        public BionosticResponsibleFull Responsible { get; set; }

        public bool IsClinic
        {
            get
            {
                if (Clinic != null)
                    return true;

                else
                    return false;
            }
        }

        public string Password
        {
            get
            {
                return IsClinic ? Clinic.Password : Responsible.Password;
            }
        }

        public string Id
        {
            get
            {
                return IsClinic ? Clinic.Id : Responsible.Id;
            }
        }

        public string Name
        {
            get
            {
                return IsClinic ? Clinic.FantasyName : Responsible.Name;
            }
        }

        public string Phone
        {
            get
            {
                return IsClinic ? Clinic.PrimaryPhone : Responsible.Contacts.FirstOrDefault(x => x.Type?.ToUpper() != "EMAIL")?.Description;
            }
        }

        public string Email
        {
            get
            {
                return IsClinic ? Clinic.Email : Responsible.Contacts.FirstOrDefault(x => x.Type?.ToUpper() == "EMAIL")?.Description;
            }
        }
    }
}

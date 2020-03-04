using System.Collections.Generic;

namespace InfinitusApp.Core.Data.DataModels
{
    public enum CustomizationReferencyDescription
    {
        None = -1,
        Application,
        SubscriptionSolution,
        DataItemPreDefinedTypes,
        Activity,
        ApplicationUserProfile
    }

    public class CustomizationApplication : Naylah.Core.Entities.EntityBase
    {
        public string ApplicationId { get; set; }

        public string ReferencyId { get; set; }

        public CustomizationReferencyDescription ReferencyDescription { get; set; }
    }

    #region MenuApp
    public class PersonalizedAppMenu : CustomizationApplication
    {
        public PersonalizedAppMenu()
        {
            Parameters = new List<PersonalizedAppMenuParameter>();

            TermsOfUse = new TermsOfUse();
        }

        public PersonalizedAppMenu(string _name, string _referencyId, string _applicationId, CustomizationReferencyDescription _referencyDescription)
        {
            Name = _name;
            ReferencyId = _referencyId;
            ApplicationId = _applicationId;
            ReferencyDescription = _referencyDescription;

            Hamburger = new Hamburger
            {
                Index = -1,
                Visible = true
            };

            Bottom = new Bottom
            {
                Visible = false,
                Index = -1,
                IsMain = false
            };

            Top = new TopMenu
            {
                Visible = false,
                Index = -1,
            };

            Parameters = new List<PersonalizedAppMenuParameter>();

            TermsOfUse = new TermsOfUse();
        }
        public string Name { get; set; }

        public Hamburger Hamburger { get; set; }

        public Bottom Bottom { get; set; }

        public TopMenu Top { get; set; }

        public MenuAppPageType PageType { get; set; }

        public string Content { get; set; }

        public MenuAppCustomType CustomType { get; set; }

        public string IconSource { get; set; }

        public MenuApplicationUserGroup Groups { get; set; }

        public TermsOfUse TermsOfUse { get; set; }

        #region Relations
        public IList<PersonalizedAppMenuParameter> Parameters { get; set; }
        #endregion

    }

    public class Hamburger : PageMenuApp
    {

    }

    public class Bottom : PageMenuApp
    {
        public bool IsMain { get; set; }
    }

    public class TopMenu : PageMenuApp
    {

    }

    public class PageMenuApp
    {
        public int Index { get; set; }

        public bool Visible { get; set; }

        //public string TextColor { get; set; }

        //public int FontSize { get; set; }

        //public string IconColor { get; set; }

        //public int IconSize { get; set; }
    }

    public enum MenuAppPageType
    {
        normal,
        site,
        custom,
        notification,
        pdfReader,
        text
    }

    public enum MenuAppCustomType
    {
        none,
        BionosticMotoboy,
        MaristaWebAluno,
        BionosticPetList,
        BionosticMedicalReportList,
        BionosticSatisfactionSurvey,
        BionosticResponsibleRegistrationChange,
        BionosticClinicRegistrationChange
    }

    public class MenuApplicationUserGroup
    {
        public MenuApplicationUserGroup()
        {
            GroupIds = new List<string>();
        }

        public IList<string> GroupIds { get; set; }
    }

    public class PersonalizedAppMenuParameter : Naylah.Core.Entities.EntityBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int Index { get; set; }

        #region Relations
        public PersonalizedAppMenu PersonalizedAppMenu { get; set; }

        public string PersonalizedAppMenuId { get; set; }
        #endregion

        
    }

  
    #endregion

    #region ApplicationUser Profile

    public class CustomizationAppUserProfile : CustomizationApplication
    {
        public bool Required { get; set; }
        public ProfileField Type { get; set; }
    }

    public enum ProfileField
    {
        Unknown,
        Adress,
        Phone,
        IdentityDocument
    }

    #endregion

    #region Visible

    public class CustomizationVisible : CustomizationApplication
    {
        public CustomizationVisible()
        {
            Activity = new ActivityVisible();
        }
        public ActivityVisible Activity { get; set; }
    }

    public class ActivityVisible
    {
        public ActivityVisible()
        {
            ActionDataItem = new List<ActionTypeDataitem>();
        }
        public IList<ActionTypeDataitem> ActionDataItem { get; set; }


        public enum ActionTypeDataitem
        {
            Undefined,
            Lead,
            Like,
            Agenda,
            EventRegistration,
            AddToCart
        }
    }
    #endregion

}
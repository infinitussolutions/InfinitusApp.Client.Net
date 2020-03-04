using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class CustomizationApp : Naylah.Core.Entities.EntityBase
    {
        public string ApplicationId { get; set; }
        public string ReferencyId { get; set; }

        public ReferencyDescription ReferencyDescription { get; set; }

        #region Relations

        public virtual DataStore DataStore { get; set; }

        public virtual string DataStoreId { get; set; }

        #endregion
    }

    public enum ReferencyDescription
    {
        Unknown = -1,
        DataItemType
    }

    #region Actions

    public class CustomizationActions : CustomizationApp
    {
        public CustomizationActions()
        {
            Actions = new ActionsCustomization();
        }
        public ActionsCustomization Actions { get; set; }

    }

    public class ActionsCustomization
    {
        public ActionsCustomization()
        {
            PossibleActionsList = new List<PossibleActionsCustomization>();
        }
        public IList<PossibleActionsCustomization> PossibleActionsList { get; set; }


        public enum PossibleActionsCustomization
        {
            Undefined,
            Lead,
            Like,
            Agenda,
            EventRegistration,
            AddToCart,
            Booking
        }
    }

    #endregion

    #region DataItem
    public class PersonalizedDataItem : CustomizationApplication
    {
        public PersonalizedDataItem()
        {

        }

        public string PlaceOfPublicationId { get; set; }
    }

    public class CustomizationDataItem : CustomizationApp
    {
        public CustomizationDataItem()
        {
            DefaultPrice = new DataItemPriceInfo();
            Agenda = new CustomizationAgenda();
        }

        public DataItemPriceInfo DefaultPrice { get; set; }
        public CustomizationAgenda Agenda { get; set; }
    }

    public class CustomizationAgenda
    {
        public int DefaultTimeSpent { get; set; }
    }
    #endregion
}

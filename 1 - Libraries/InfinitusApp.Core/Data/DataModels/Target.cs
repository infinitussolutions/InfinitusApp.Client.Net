using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static InfinitusApp.Core.Data.DataModels.TargetFilter;
using static InfinitusApp.Core.Data.Enums.DataItemEnums;

namespace InfinitusApp.Core.Data.DataModels
{
    public class Target
    {
        public Target()
        {
            TargetInfo = new TargetInfo();
        }

        public TargetInfo TargetInfo { get; set; }

        public string Parameter { get; set; }

        #region Helps

        [JsonIgnore]
        public DataItemType ParameterInType
        {
            get
            {
                if (string.IsNullOrEmpty(Parameter))
                    return DataItemType.NotFound;

                Enum.TryParse<DataItemType>(Parameter, out var type);

                return type;
            }
        }

        [JsonIgnore]
        public bool AllowOrderType
        {
            get
            {
                if (TargetInfo == null || TargetInfo.NavigationType != NavigationType.List)
                    return false;

                switch (TargetInfo.Page)
                {
                    default: return false;

                    case PageNameType.DataItem:
                    case PageNameType.CustomPage:
                    case PageNameType.DataItemFavorite:
                    case PageNameType.DataItemRecentOrder:
                    case PageNameType.Tag:
                        return true;
                }
            }
        }
        [JsonIgnore]
        public bool AllowInDashboard
        {
            get
            {
                if (TargetInfo == null)
                    return false;

                switch (TargetInfo.Page)
                {
                    default: return false;

                    case PageNameType.DataItem:
                    case PageNameType.DataItemFavorite:
                    case PageNameType.DataItemGroup:
                    case PageNameType.DataItemRecentOrder:
                    case PageNameType.Publications:
                    case PageNameType.Tag:
                        return true;
                }
            }
        }
        [JsonIgnore]
        public bool AllowNavigationType
        {
            get
            {
                if (TargetInfo == null)
                    return false;

                switch (TargetInfo.Page)
                {
                    default: return false;

                    case PageNameType.DataItem:
                    case PageNameType.CustomPage:
                    case PageNameType.Tag:
                        return true;
                }
            }
        }
        [JsonIgnore]
        public string PagePresentation
        {
            get
            {
                var title = string.Empty;

                switch (TargetInfo.Page)
                {
                    case PageNameType.AboutApp: title += "Sobre o App"; break;
                    case PageNameType.Preference: title += "Preferências"; break;
                    case PageNameType.AboutCompany: title += "Sobre a Empresa"; break;
                    case PageNameType.Appointment: title += "Agendamentos"; break;
                    case PageNameType.CustomPage: title += "Menu Personalizado"; break;
                    case PageNameType.DataItemRecentOrder: title += "Itens Recentes"; break;
                    case PageNameType.FinancialRequest: title += "Pedidos de Venda"; break;
                    case PageNameType.Home: title += "Início"; break;
                    case PageNameType.InviteApp: title += "Convites"; break;
                    case PageNameType.Logout: title += "Sair"; break;
                    case PageNameType.Notifications: title += "Notificações"; break;
                    case PageNameType.Publications: title += "Publicações"; break;
                    case PageNameType.SelectSegment: title += "Selecionar Segmento"; break;
                    case PageNameType.UserProfile: title += "Perfil"; break;
                    case PageNameType.Website: title += "Website"; break;
                    case PageNameType.WhatsApp: title += "WhatsApp Businnes"; break;
                    case PageNameType.DataItem: title += "DataItem"; break;
                    case PageNameType.DataItemFavorite: title += "Favoritos"; break;
                    case PageNameType.DataItemGroup: title += "Grupo de DataItem"; break;
                    case PageNameType.TicketSale: title += "Venda de Ingressos"; break;
                    case PageNameType.Tag: title += "Tag"; break;
                    case PageNameType.Signature: title += "Assinaturas"; break;
                }

                return title;
            }
        }
        [JsonIgnore]
        public TargetPageParameter PageParameter { get; set; }
        #endregion

    }

    public class TargetInfo
    {
        public TargetInfo()
        {
            TargetEditConfig = new TargetEditConfig();
            Filter = new TargetFilter();
            NavigationParameter = new TargetNavigationParameter();
        }

        public NavigationType NavigationType { get; set; }

        public PageNameType Page { get; set; }

        public PageOrderType OrderType { get; set; }

        public TargetEditConfig TargetEditConfig { get; set; }

        public TargetFilter Filter { get; set; }
        public TargetNavigationParameter NavigationParameter { get; set; }

    }

    public class TargetEditConfig
    {
        public bool CreateActive { get; set; }
    }

    public class TargetFilter
    {
        public TargetFilter()
        {
            DataItem = new TargetFilterDataItem();
        }

        public TargetFilterDataItem DataItem { get; set; }

        public enum TargetFilterOption
        {
            All,
            True,
            False
        }
    }

    public class TargetFilterDataItem
    {
        public TargetFilterOption AllowInHands { get; set; }

        public TargetFilterOption AllowBooking { get; set; }

        public TargetFilterOption AllowDelivery { get; set; }
    }

    public enum NavigationType
    {
        List,
        Detail,
        Edit,
        ListItems
    }

    public enum PageNameType
    {
        DataItem,
        WhatsApp,
        Appointment,
        CustomPage,
        Website,
        Notifications,
        Publications,
        UserProfile,
        AboutCompany,
        FinancialRequest,
        Home,
        AboutApp,
        Logout,
        SelectSegment,
        DataItemGroup,
        DataItemFavorite,
        DataItemRecentOrder,
        InviteApp,
        TicketSale,
        Tag,
        Preference,
        Signature
    }

    public enum PageOrderType
    {
        Date,
        Alphabetic,
        Distance,
        Rating,
        EventDate
    }

    public class TargetPageParameter
    {
        public string PageTitle { get; set; }
        public string Parameter { get; set; }
    }

    public class TargetNavigationParameter
    {
        public NavigationObjective Objective { get; set; }

        public enum NavigationObjective
        {
            Normal,
            FinancialRequest
        }
    }

}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class StructureConfiguration : Naylah.Core.Entities.EntityBase
    {
        public StructureConfiguration()
        {
            Icon = new FontIcon();
           // OnPart = new ExtendConfiguration();
            Target = new Target();
            TargetGroups = new List<ApplicationUserGroup>();
            TermsOfUse = new TermsOfUse();
        }

        public StructureConfiguration(StructureConfiguration structure)
        {
            Application = structure.Application;
            ApplicationId = structure.ApplicationId;
            Index = structure.Index;
            //OnPart = structure.OnPart;
            Position = structure.Position;
            Target = structure.Target;
            TargetGroups = structure.TargetGroups;
            TermsOfUse = structure.TermsOfUse;
            Title = structure.Title;
            Icon = new FontIcon(structure.Icon);
            
        }

        public string Title { get; set; }

        public int Index { get; set; }

        public FontIcon Icon { get; set; }

        //public ExtendConfiguration OnPart { get; set; }

        public Target Target { get; set; }

        public TermsOfUse TermsOfUse { get; set; }

        public StructurePosition Position { get; set; }

        public StructureType Type { get; set; }

        public string Presentation { get; set; }

        #region Relations

        public Application Application { get; set; }

        public string ApplicationId { get; set; }

        public IList<ApplicationUserGroup> TargetGroups { get; set; }

        #endregion

        public enum StructurePosition
        {
            Hamburger,
            Dashboard,
            Bottom,
            Top
        }

        public enum StructureType
        {
            Default,
            User
        }

        #region Helps
        [JsonIgnore]
        public bool IsDashboard
        {
            get
            {
                return Position == StructurePosition.Dashboard;
            }
        }
        [JsonIgnore]
        public bool Visible { get; set; }

        public bool IsVisible(ApplicationUser user)
        {
            if (TargetGroups.Count == 0)
                return true;

            else
            {
                if (user == null)
                    return false;

                return user.Groups.Any(x => TargetGroups.Any(g => g.Id.Equals(x.Id)));
            }
        }
        

        #endregion
    }

    public class ExtendConfiguration
    {
        public ExtendConfiguration()
        {
            Dashboard = new DashboardConfiguration();
           // Menu = new ExtendMenuConfiguration();
        }

        public DashboardConfiguration Dashboard { get; set; }

     //   public ExtendMenuConfiguration Menu { get; set; }
    }

    public class ExtendMenuConfiguration
    {
        public ExtendMenuConfiguration()
        {
            Hamburguer = new MenuHamburguerConfiguration();
            Top = new MenuTopConfiguration();
            Bottom = new MenuBottomConfiguration();
        }

        public MenuHamburguerConfiguration Hamburguer { get; set; }

        public MenuTopConfiguration Top { get; set; }

        public MenuBottomConfiguration Bottom { get; set; }
    }

    public class DashboardConfiguration
    {
        public DashboardConfiguration()
        {

        }

        public DashboardItensOrder OrderType { get; set; }

        public enum DashboardItensOrder
        {
            Date,
            Alphabetic,
            Distance
        }
    }

    public class MenuConfigurationBase
    {
        public MenuConfigurationBase()
        {

        }
    }

    public class MenuHamburguerConfiguration : MenuConfigurationBase
    {

    }

    public class MenuTopConfiguration : MenuConfigurationBase
    {

    }

    public class MenuBottomConfiguration : MenuConfigurationBase
    {

    }
}

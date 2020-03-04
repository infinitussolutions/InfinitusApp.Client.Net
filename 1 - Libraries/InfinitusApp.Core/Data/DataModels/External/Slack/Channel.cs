using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Slack
{
    public class Channel
    {
        public static string GetByChannelType(ChannelType channelType)
        {
            switch (channelType)
            {
                case ChannelType.BugsReport:
                    return "#bugsreport";
                case ChannelType.DevNotifications:
                    return "#devnotifications";
                case ChannelType.General:
                    return "#general";
                default:
                    return "#general";
            }
        }
    }

    public enum ChannelType
    {
        BugsReport,
        DevNotifications,
        General
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTrackr.Configuration;
using System.Configuration;

namespace CarTrackr.Extensions
{
    public static class ServiceStationExtensions
    {
        public static string ServiceStationImage(this HtmlHelper html, string serviceStationName)
        {
            // Image URL
            string imageUrl = "/Content/ServiceStations/none.gif";

            // Read configuration
            CarTrackrConfigurationSection configuration = ConfigurationManager.GetSection("carTrackr") as CarTrackrConfigurationSection;

            // Lookup service station name
            foreach (ServiceStation serviceStation in configuration.serviceStations)
            {
                if (serviceStationName.ToLowerInvariant().Contains(serviceStation.name.ToLowerInvariant()))
                {
                    imageUrl = serviceStation.logoUrl;
                    break;
                }
            }

            // Build image tag
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", "" + imageUrl);
            builder.Attributes.Add("border", "0");
            builder.Attributes.Add("alt", serviceStationName);
            builder.Attributes.Add("align", "absmiddle");

            return builder.ToString(TagRenderMode.SelfClosing);
        }
    }
}

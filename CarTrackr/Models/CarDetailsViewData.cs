using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CarTrackr.Domain;
using System.Collections.Generic;

namespace CarTrackr.Models
{
    public class CarDetailsViewData
    {
        public Car Car { get; set; }
        public decimal TotalKilometers { get; set; }
        public decimal AverageUsage { get; set; }
        public decimal TotalCosts { get; set; }
        public decimal AverageCosts { get; set; }
    }
}
 
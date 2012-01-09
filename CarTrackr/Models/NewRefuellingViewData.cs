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

namespace CarTrackr.Models
{
    public class NewRefuellingViewData
    {
        public Car Car { get; set; }
        public Refuelling LastRefuelling { get; set; }
        public Refuelling NewRefuelling { get; set; }
    }
}

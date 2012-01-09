﻿using System;
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
using CarTrackr.Core;
using System.Collections.Generic;

namespace CarTrackr.Controllers
{
    public interface IRuleEntity
    {
        void EnsureValid();
        List<RuleViolation> GetRuleViolations();
    }
}

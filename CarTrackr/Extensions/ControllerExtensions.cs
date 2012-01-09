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
using CarTrackr.Controllers;
using System.Web.Mvc;
using CarTrackr.Core;
using System.Collections.Generic;

namespace CarTrackr.Extensions
{
    public static class ControllerExtensions
    {
        public static void UpdateModelStateWithViolations(this Controller current, IRuleEntity entity, ModelStateDictionary modelState)
        {
            List<RuleViolation> productIssues = entity.GetRuleViolations();

            foreach (var issue in productIssues)
            {
                modelState.AddModelError(issue.PropertyName,
                                          issue.ErrorMessage);
            }
        }
    }
}

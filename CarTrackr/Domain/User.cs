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
using CarTrackr.Core;
using System.Collections.Generic;
using System.Data.Linq;

namespace CarTrackr.Domain
{
    public partial class User : IRuleEntity
    {
        public List<RuleViolation> GetRuleViolations()
        {
            List<RuleViolation> validationIssues = new List<RuleViolation>();

            return validationIssues;
        }

        public void EnsureValid()
        {
            List<RuleViolation> issues = GetRuleViolations();

            if (issues.Count != 0)
                throw new RuleViolationException("Business Rule Violations", issues);
        }

        partial void OnValidate(ChangeAction action)
        {
            EnsureValid();
        }
    }
}

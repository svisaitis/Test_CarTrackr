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
    public partial class Refuelling : IRuleEntity
    {
        public List<RuleViolation> GetRuleViolations()
        {
            List<RuleViolation> validationIssues = new List<RuleViolation>();

            if (Date == null)
                validationIssues.Add(new RuleViolation("Date", Date, "Date should be specified!"));

            if (Kilometers < 0)
                validationIssues.Add(new RuleViolation("Kilometers", Kilometers, "Kilometers should be specified!"));

            if (Liters < 0)
                validationIssues.Add(new RuleViolation("Liters", Liters, "Liters should be specified!"));

            if (PricePerLiter < 0)
                validationIssues.Add(new RuleViolation("PricePerLiter", PricePerLiter, "Price per liter should be specified!"));

            if (Total < 0)
                validationIssues.Add(new RuleViolation("Total", Total, "Total should be specified!"));

            if (Usage < 0)
                validationIssues.Add(new RuleViolation("Usage", Usage, "Usage should be specified!"));

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

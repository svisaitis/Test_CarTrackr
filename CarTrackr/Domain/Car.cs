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
    public partial class Car : IRuleEntity
    {
        public List<RuleViolation> GetRuleViolations()
        {
            List<RuleViolation> validationIssues = new List<RuleViolation>();

            if (string.IsNullOrEmpty(Make))
                validationIssues.Add(new RuleViolation("Make", Make, "Make should be specified!"));

            if (string.IsNullOrEmpty(Model))
                validationIssues.Add(new RuleViolation("Model", Model, "Model should be specified!"));

            if (PurchasePrice <= 0)
                validationIssues.Add(new RuleViolation("PurchasePrice", PurchasePrice, "Purchase price should be specified!"));

            if (string.IsNullOrEmpty(LicensePlate))
                validationIssues.Add(new RuleViolation("LicensePlate", LicensePlate, "License plate should be specified!"));

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

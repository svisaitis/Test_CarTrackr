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
using System.Collections.Generic;

namespace CarTrackr.Core
{
    public class RuleViolationException : Exception
    {
        public List<RuleViolation> Issues { get; private set; }

        public RuleViolationException() : base() { }
        public RuleViolationException(string message) : base(message) { }
        public RuleViolationException(string message, Exception innerException) : base(message, innerException) { }
        public RuleViolationException(string message, List<RuleViolation> issues)
            : base(message)
        {
            Issues = issues;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace CarTrackr.Core
{
    public class RuleViolation
    {
        public string PropertyName { get; private set; }
        public object PropertyValue { get; private set; }
        public string ErrorMessage { get; private set; }

        public RuleViolation(string propertyName, object propertyValue, string errorMessage)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            ErrorMessage = errorMessage;
        }
    }
}

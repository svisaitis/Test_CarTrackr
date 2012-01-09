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
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace CarTrackr.Core
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        IUnityContainer container;

        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }
        
        protected override IController GetControllerInstance(Type controllerType)
        {
            IController controller = null;

            if (controllerType != null)
            {

                if (!typeof(IController).IsAssignableFrom(controllerType))
                    throw new ArgumentException(string.Format(
                        "Type requested is not a controller: {0}", controllerType.Name),
                        "controllerType");

                controller = container.Resolve(controllerType) as IController;
            }

            return controller;
        }
    }
}

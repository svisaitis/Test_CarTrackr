using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CarTrackr.Data;
using System.Data.Linq;
using CarTrackr.Domain;
using Microsoft.Practices.Unity;
using CarTrackr.Core;
using CarTrackr.Controllers;
using System.Web.Security;
using CarTrackr.Repository;

namespace CarTrackr
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "CarDetails",                                                   
                "Car/{licensePlate}/{action}",                                 
                new { controller = "Car", action = "List", licensePlate = "" },
                new { licensePlate = @"(.+)" } 
            );

            routes.MapRoute(
                "CarRefuellings",
                "Car/{licensePlate}/Refuellings/{action}",
                new { controller = "Refuelling", action = "Index", licensePlate = "" },
                new { licensePlate = @"(.+)" } 
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            RegisterDependencies();
        }

        protected static void RegisterDependencies() {
            IUnityContainer container = new UnityContainer();

            // Registrations
            container.RegisterType<IFormsAuthentication, FormsAuthenticationWrapper>();
            container.RegisterInstance<MembershipProvider>(Membership.Provider);

            container.RegisterType<CarTrackrData, CarTrackrData>(new ContextLifetimeManager<CarTrackrData>());
            container.RegisterType<ICarRepository, CarRepository>(new ContextLifetimeManager<ICarRepository>());
            container.RegisterType<IUserRepository, UserRepository>(new ContextLifetimeManager<IUserRepository>());
            container.RegisterType<IRefuellingRepository, RefuellingRepository>(new ContextLifetimeManager<IRefuellingRepository>());
            container.RegisterType<ICostsRepository, CostsRepository>(new ContextLifetimeManager<ICostsRepository>());

            // Set controller factory
            ControllerBuilder.Current.SetControllerFactory(
                new UnityControllerFactory(container)    
            );
        }
    }
}
using AglDeveloperTest.BusinessLayer;
using AglDeveloperTest.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace AglDeveloperTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterUnityComponents();
        }

        public static void RegisterUnityComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IDataService, DataService>();
            container.RegisterType<IDataRepositry, DataRepositry>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}

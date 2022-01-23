using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BloodDoner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Emp",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Emp", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}

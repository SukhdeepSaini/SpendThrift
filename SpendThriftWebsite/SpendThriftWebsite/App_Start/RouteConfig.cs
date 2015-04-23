using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpendThriftWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Queries Actions",
            url: "Queries/{action}",
            defaults: new { controller = "Queries", action = "Index" }
            );

            routes.MapRoute(
            name: "Customer Actions",
            url: "Customer/{action}",
            defaults: new { controller = "Customer", action = "Index" }
            );

            routes.MapRoute(
            name: "Product Actions",
            url: "Product/{action}",
            defaults: new { controller = "Product", action = "Create" }
            );

            routes.MapRoute(
                    name: "Product Store",
                    url: "Store/{action}/{id}",
                    defaults: new { controller = "Store", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
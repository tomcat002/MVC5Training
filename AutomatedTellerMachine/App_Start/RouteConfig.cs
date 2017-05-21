﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutomatedTellerMachine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //This line enables RouteAttribute
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Serial Number",
                url: "Serial/{letterCase}",
                defaults: new { controller = "Home", action = "serial", letterCase = "upper" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}

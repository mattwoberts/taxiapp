using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TaxiApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//            routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );            
            
            routes.MapHttpRoute(
                name: "TaxiApi",
                routeTemplate: "api/taxi/{lat}/{lon}/{name}/{mobile}", 
                defaults: new {controller = "Taxi", lat = RouteParameter.Optional, lon = RouteParameter.Optional,
                name = RouteParameter.Optional, mobile = RouteParameter.Optional}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
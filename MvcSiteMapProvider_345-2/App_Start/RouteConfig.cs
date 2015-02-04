using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcSiteMapProvider_345_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // MvcSiteMapProvider XML sitemap routes
            var registrar = new MvcSiteMapProvider.Web.Routing.XmlSitemapFeedRouteRegistrar();
            registrar.RegisterRoutes(routes, "XmlSitemap2", "Index");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ); 
        }
    }
}
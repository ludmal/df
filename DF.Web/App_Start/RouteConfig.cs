using System.Web.Mvc;
using System.Web.Routing;

namespace DF.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("Category", "category/{cat}", new {controller = "Home", action = "Category"}
            //    );

            //routes.MapRoute("Partners", "partners/{slug}", new {controller = "Home", action = "Partners"}
            //    );

            //routes.MapRoute("Search", "search/{keyword}", new {controller = "Home", action = "Search"}
            //    );
            //routes.MapRoute("Deals", "deals/{slug}", new {controller = "Home", action = "Deals"}
            //    );


            //routes.MapRoute("DealsLK", "lk",
            //    new { controller = "Home", action = "Main", id = UrlParameter.Optional }
            //    );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Main", id = UrlParameter.Optional }
                );

        }
    }
}
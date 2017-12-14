using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTests
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // Add attribute routing as .. well its so much easier... and you commented the other one out .. so just sayin!
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Test", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}

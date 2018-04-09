using Agio.Flights.Presentation.Infrastructure;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Agio.Flights.Presentation
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependencyInjection.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapping.Configure();
        }
    }
}

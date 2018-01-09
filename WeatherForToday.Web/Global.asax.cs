using System.Web.Mvc;
using System.Web.Routing;
using WeatherForToday.Web.Infrastructure.DI;

namespace WeatherForToday.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var dependencyResolverFactory = new AutofacContainerFactory();
            DependencyResolver.SetResolver(dependencyResolverFactory.Create());
        }
    }
}

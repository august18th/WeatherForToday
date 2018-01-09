using System.Web.Mvc;

namespace WeatherForToday.Web.Infrastructure.DI
{
    public interface IDependencyResolverFactory
    {
        IDependencyResolver Create();
    }
}
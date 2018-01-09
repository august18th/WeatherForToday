using System.Web.Mvc;
using Autofac;
using WeatherForToday.Services.Interfaces;
using WeatherForToday.Services.Services;
using Autofac.Integration.Mvc;

namespace WeatherForToday.Web.Infrastructure.DI
{
    public class AutofacContainerFactory : IDependencyResolverFactory
    {
        public IDependencyResolver Create()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WeatherService>().As<IWeatherService>().InstancePerRequest();
            builder.RegisterControllers(GetType().Assembly);

            return new AutofacDependencyResolver(builder.Build());
        }
    }
}
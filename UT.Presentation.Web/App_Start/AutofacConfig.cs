using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace UT.Presentation.Web
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var settingsReader = new ConfigurationSettingsReader();
            builder.RegisterModule(settingsReader);

            var container = builder.Build();
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
        }
    }
}
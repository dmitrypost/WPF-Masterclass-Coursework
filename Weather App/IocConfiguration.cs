using Autofac;
using System;
using Weather.Views;

namespace Weather
{
    public static class IocConfiguration
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterType<MainWindow>();
            
            return builder.Build();
        }
    }
}

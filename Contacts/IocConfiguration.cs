using Autofac;
using System;

namespace Contacts
{
    public static class IocConfiguration
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterType<ContactWindow>();

            return builder.Build();
        }
    }
}

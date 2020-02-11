using Autofac;
using System.Windows;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IocContainer = IocConfiguration.ConfigureContainer();
        }

        public static IContainer IocContainer { get; private set; }
    }
}

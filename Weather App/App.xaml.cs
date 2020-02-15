using System.Windows;
using Autofac;

namespace Weather
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer IocContainer = IocConfiguration.ConfigureContainer();

        public App()
        {
            
        }
    }
}

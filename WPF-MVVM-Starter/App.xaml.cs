using System.Windows;

using Autofac;
using Model;
using ViewModel;
using View;

namespace WPF_MVVM_Starter
{
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            RegisterDependencies(builder);
            var container = builder.Build();

            StartApplication(container);
        }

        private void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<MainModel>().As<IMainModel>();
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<MainWindow>();
        }

        private static void StartApplication(IContainer container)
        {
            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
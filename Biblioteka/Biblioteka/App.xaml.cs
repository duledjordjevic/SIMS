using Autofac;
using Biblioteka.Configuration;
using Biblioteka.Service.Interface;
using Biblioteka.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Biblioteka
{
    public partial class App : Application
    {
        public App() { }

        protected override void OnStartup(StartupEventArgs e)
        {
            var container = ContainerConfiguration.Configure();

            ILoginService loginService;

            using (var scope = container.BeginLifetimeScope())
            {
                loginService = scope.Resolve<ILoginService>();

            }
                MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(loginService)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}

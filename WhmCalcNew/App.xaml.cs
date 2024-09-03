using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WhmCalcNew.Services;
using WhmCalcNew.Services.Calculations;
using WhmCalcNew.Services.DataAccess;
using WhmCalcNew.ViewModel;
using WhmCalcNew.Views;

namespace WhmCalcNew
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                // Сервисы
                services.AddSingleton<IWhmDbService, WhmDbService>();
                services.AddSingleton<IModListService, ModListService>();
                services.AddSingleton<ITargetsListService, TargetsListService>();
                services.AddSingleton<ICalcOutputService, CalcOutputService>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<AddTargetWindow>();

            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            base.OnStartup(e);
            await ModListService.Initialize();

            using (DataContext dbContext = new DataContext())
            {
                dbContext.Database.Migrate();
            }

                var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}

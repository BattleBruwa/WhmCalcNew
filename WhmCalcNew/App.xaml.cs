﻿using System.Windows;
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
                services.AddTransient<IWhmDbService, WhmDbService>();
                services.AddSingleton<IModListService, ModListService>();
                services.AddSingleton<ICalcOutputService, CalcOutputService>();
                services.AddSingleton<MainViewModel>();
                services.AddTransient<AddTargetViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddTransient<AddTargetWindow>();

            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            base.OnStartup(e);

            using (DataContext dbContext = new DataContext())
            {
                dbContext.Database.Migrate();
            }

            var modsList = AppHost.Services.GetRequiredService<IModListService>();
            await modsList.InitializeModListAsync();

            var viewModel = AppHost.Services.GetRequiredService<MainViewModel>();
            await viewModel.FillTargetsCollectionAsync(AppHost.Services.GetRequiredService<IWhmDbService>());

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

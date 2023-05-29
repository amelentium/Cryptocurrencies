using CIS.AbstractFavtory;
using CIS.Services;
using CIS.Stores;
using CIS.ViewModels;
using CIS.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CIS;

public partial class App : Application
{
	public static IHost? AppHost { get; private set; }

	public App()
	{
		AppHost = Host.CreateDefaultBuilder()
			.ConfigureServices((context, services) =>
			{
				services.AddSingleton<MainWindow>();
				services.AddTransient<CurrenciesView>();
				services.AddTransient<CurrencyInfoView>();

				services.AddSingleton<MainViewModel>();
				services.AddViewModelFactory<CurrenciesViewModel>();
				services.AddViewModelFactory<CurrencyInfoViewModel>();
				services.AddSingleton(typeof(IAbstractFactory<>), typeof(AbstractFactory<>));

				services.AddHttpClient();
				services.AddSingleton<NavigationStore>();
				services.AddSingleton(typeof(INavigationService<>), typeof(NavigationService<>));
				services.AddTransient<ICurrencyService, CurrencyService>();
			})
			.Build();
	}

	protected override async void OnStartup(StartupEventArgs e)
	{
		await AppHost!.StartAsync();

		var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
		startupForm.Show();

		base.OnStartup(e);
	}

	protected override async void OnExit(ExitEventArgs e)
	{
		await AppHost!.StopAsync();

		base.OnExit(e);
	}
}

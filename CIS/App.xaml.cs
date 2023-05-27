using CIS.Services;
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

				services.AddHttpClient();
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

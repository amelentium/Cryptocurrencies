using CIS.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CIS.AbstractFavtory;

public static class ServiceExtentions
{
	public static void AddViewModelFactory<TViewModel>(this IServiceCollection services) where TViewModel : ViewModelBase
	{
		services.AddTransient<TViewModel>();
		services.AddSingleton<Func<TViewModel>>(x => () => x.GetService<TViewModel>()!);
	}
}

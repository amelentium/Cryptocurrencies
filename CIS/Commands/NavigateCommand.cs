using CIS.Services;
using CIS.ViewModels;
using System;

namespace CIS.Commands;

public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
{
	private readonly INavigationService<TViewModel> _navigationService;

	public Action<CurrencyInfoViewModel, object?[]?>? PostNavigateAction { get; set; }

	public NavigateCommand(INavigationService<TViewModel> navigationService)
	{
		_navigationService = navigationService;
	}

	public override void Execute(object? parameter)
	{
		if (PostNavigateAction == null)
		{
			_navigationService.Navigate();
		}
		else
		{
			_navigationService.Navigate(PostNavigateAction, parameter);
		}
	}
}

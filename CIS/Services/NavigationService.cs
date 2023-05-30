using CIS.AbstractFavtory;
using CIS.Stores;
using CIS.ViewModels;
using System;

namespace CIS.Services;

public class NavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
{
	private readonly NavigationStore _navigationStore;
	private readonly IAbstractFactory<TViewModel> _viewModelFactory;

	public NavigationService(NavigationStore navigationStore, IAbstractFactory<TViewModel> viewModelFactory)
	{
		_navigationStore = navigationStore;
		_viewModelFactory = viewModelFactory;
	}

	public void Navigate()
	{
		_navigationStore.CurrentViewModel = _viewModelFactory.Create();
	}

	public void Navigate<TAction>(TAction postAction, params object?[]? args) where TAction : Delegate
	{
		Navigate();

		postAction.DynamicInvoke(_navigationStore.CurrentViewModel, args);
	}
}

using CIS.AbstractFavtory;
using CIS.Stores;
using CIS.ViewModels;

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
}

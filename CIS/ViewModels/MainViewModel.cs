using CIS.AbstractFavtory;
using CIS.Stores;

namespace CIS.ViewModels;

public class MainViewModel : ViewModelBase
{
	private readonly NavigationStore _navigationStore;

	public ViewModelBase? CurrentViewModel => _navigationStore.CurrentViewModel;

	public MainViewModel(NavigationStore navigationStore, IAbstractFactory<CurrenciesViewModel> currenciesFactory)
	{
		_navigationStore = navigationStore;
		_navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
		_navigationStore.CurrentViewModel = currenciesFactory.Create();
	}

	private void OnCurrentViewModelChanged()
	{
		OnPropertyChanged(nameof(CurrentViewModel));
	}
}

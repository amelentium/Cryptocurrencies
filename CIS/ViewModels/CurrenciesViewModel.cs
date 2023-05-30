using CIS.Commands;
using CIS.Models;
using CIS.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CIS.ViewModels;

public class CurrenciesViewModel : ViewModelBase
{
	private readonly ICurrencyService _currencyService;
	private List<CurrencyModel>? currencies;
	private string searchValue;

	public List<CurrencyModel>? Currencies
	{
		get => currencies;
		set { currencies = value; OnPropertyChanged(nameof(Currencies)); }
	}
	
	public string SearchValue
	{
		get => searchValue;
		set { searchValue = value; OnPropertyChanged(nameof(SearchValue)); }
	}

	public ICommand CurrencyInfoNavigateCommand { get; init; }

	public ICommand SearchCurrencyCommand { get; init; }

	public CurrenciesViewModel(ICurrencyService currencyService, NavigateCommand<CurrencyInfoViewModel> currencyInfoNavigateCommand)
	{
		currencyInfoNavigateCommand.PostNavigateAction = new Action<CurrencyInfoViewModel, object?[]?>(
			async (viewModel, args) => await viewModel.LoadCurrencyData((string)args[0]));
		CurrencyInfoNavigateCommand = currencyInfoNavigateCommand;

		SearchCurrencyCommand = new RelayCommand(async o => await CurrencySearch());

		_currencyService = currencyService;
		LoadCurrenciesData();
	}

	private async Task LoadCurrenciesData()
	{
		Currencies = await _currencyService.GetCurrenciesAsync();
	}

	public async Task CurrencySearch()
	{
		if (string.IsNullOrWhiteSpace(SearchValue))
		{
			await LoadCurrenciesData();
		}
		else
		{
			Currencies = await _currencyService.SearchCurrency(SearchValue);
		}
	}
}

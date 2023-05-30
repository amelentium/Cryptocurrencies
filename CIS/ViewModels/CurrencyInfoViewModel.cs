using CIS.Commands;
using CIS.Models;
using CIS.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CIS.ViewModels;

public class CurrencyInfoViewModel : ViewModelBase
{
	private CurrencyModel? currency;
	private List<CurrencyMarket>? currencyMarkets;
	private readonly ICurrencyService _currencyService;

	public CurrencyModel? Currency
	{
		get => currency;
		set { currency = value; OnPropertyChanged(nameof(Currency)); }
	}

	public List<CurrencyMarket>? CurrencyMarkets
	{
		get => currencyMarkets;
		set { currencyMarkets = value; OnPropertyChanged(nameof(CurrencyMarkets)); }
	}

	public ICommand CurrenciesNavigateCommand { get; init; }

	public CurrencyInfoViewModel(ICurrencyService currencyService, NavigateCommand<CurrenciesViewModel> currenciesNavigateCommand)
	{
		_currencyService = currencyService;
		CurrenciesNavigateCommand = currenciesNavigateCommand;
	}

	public async Task LoadCurrencyData(string currencyId)
	{
		Currency = await _currencyService.GetCurrencyByIdAsync(currencyId);
		CurrencyMarkets = await _currencyService.GetCurrencyMarketsAsync(currencyId);
	}
}

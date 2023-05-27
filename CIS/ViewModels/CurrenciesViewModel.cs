using CIS.Models;
using CIS.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIS.ViewModels;

public class CurrenciesViewModel : ViewModelBase
{
	private readonly ICurrencyService _currencyService;

	private List<CurrencyModel>? currencies;
	public List<CurrencyModel>? Currencies 
	{
		get => currencies;
		set { currencies = value; OnPropertyChanged(nameof(Currencies)); }
	}

	public CurrenciesViewModel(ICurrencyService currencyService)
	{
		_currencyService = currencyService;
		LoadData();
	}

	private async Task LoadData()
	{
		Currencies = await _currencyService.GetAssets();
	}
}

using CIS.Models;
using CIS.Services;
using System.Threading.Tasks;

namespace CIS.ViewModels;

public class CurrencyInfoViewModel : ViewModelBase
    {
	private CurrencyModel? currency;
	private readonly ICurrencyService _currencyService;

	public CurrencyModel? Currency
	{
		get => currency;
		set { currency = value; OnPropertyChanged(nameof(Currency)); }
	}

	public CurrencyInfoViewModel(ICurrencyService currencyService)
	{
		_currencyService = currencyService;
		LoadData();
	}

	private async Task LoadData()
	{
		Currency = await _currencyService.GetAssetById("bitcoin");
	}
}

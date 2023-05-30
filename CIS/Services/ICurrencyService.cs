using CIS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIS.Services;

public interface ICurrencyService
{
	Task<List<CurrencyModel>?> GetCurrenciesAsync();
	Task<CurrencyModel?> GetCurrencyByIdAsync(string currencyId);
	Task<List<CurrencyMarket>?> GetCurrencyMarketsAsync(string currencyId);
	Task<List<CurrencyModel>?> SearchCurrency(string nameToSearch);
}
using CIS.Models;
using CIS.Models.CoinCap;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CIS.Services;

public class CurrencyService : ICurrencyService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly JsonSerializerOptions _serializerOptions;

	public CurrencyService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
		_serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
	}

	public async Task<List<CurrencyModel>?> GetCurrenciesAsync()
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();

		try
		{
			var assets = await httpClient.GetFromJsonAsync<AssetsResponse>(Constants.CoinCapAPI.AssetsUrl, _serializerOptions);

			return assets?.Data;
		}
		catch
		{
			return null;
		}
	}

	public async Task<CurrencyModel?> GetCurrencyByIdAsync(string currencyId)
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();

		var requestUrl = string.Format(Constants.CoinCapAPI.AssetsByIdUrlTemplate, currencyId);

		try
		{
			var asset = await httpClient.GetFromJsonAsync<AssetByIdResponse>(requestUrl, _serializerOptions);

			return asset?.Data;
		}
		catch
		{
			return null;
		}
	}

	public async Task<List<CurrencyMarketModel>?> GetCurrencyMarketsAsync(string currencyId)
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();

		var requestUrl = string.Format(Constants.CoinCapAPI.AssetMarketsUrlTemplate, currencyId);

		try
		{
			var assetMarkets = await httpClient.GetFromJsonAsync<AssetMarketsResponse>(requestUrl, _serializerOptions);

			var markets = assetMarkets?.Data?
				.Where(market => market.BaseId == currencyId && market.QuoteSymbol == Constants.CoinCapAPI.QuoteSymbol.USD)
				.OrderByDescending(market => market.PriceUsd)
				.ToList();

			return markets;
		}
		catch
		{
			return null;
		}
	}

	public async Task<List<CurrencyModel>?> SearchCurrency(string nameToSearch)
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();

		var requestUrl = string.Format(Constants.CoinCapAPI.AssetSearchUrlTemplate, nameToSearch.ToLower());

		try
		{
			var assets = await httpClient.GetFromJsonAsync<AssetsResponse>(requestUrl, _serializerOptions);

			return assets?.Data;
		}
		catch
		{
			return null;
		}
	}

	public async Task<List<CurrencyHistoryValueModel>?> GetCurrencyHistoryAsync(string currencyId)
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();

		var requestUrl = string.Format(Constants.CoinCapAPI.AssetHistoryUrlTemplate, currencyId);

		try
		{
			var historyResponse = await httpClient.GetFromJsonAsync<AssetHistoryResponse>(requestUrl, _serializerOptions);

			return historyResponse?.Data?
				.OrderBy(x => x.Date)
				.ToList();
		}
		catch
		{
			return null;
		}
	}
}

using CIS.Constants;
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

		var assets = await httpClient.GetFromJsonAsync<AssetsResponse>(CoinCapAPI.AssetsUrl, _serializerOptions);

		return assets?.Data;
	}

	public async Task<CurrencyModel?> GetCurrencyByIdAsync(string currencyId)
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();

		var requestUrl = string.Format(CoinCapAPI.AssetsByIdUrlTemplate, currencyId);

		var asset = await httpClient.GetFromJsonAsync<AssetByIdResponse>(requestUrl, _serializerOptions);

		return asset?.Data;
	}

	public async Task<List<CurrencyMarket>?> GetCurrencyMarketsAsync(string currencyId)
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();

		var requestUrl = string.Format(CoinCapAPI.AssetMarketsUrlTemplate, currencyId);

		var assetMarkets = await httpClient.GetFromJsonAsync<AssetMarkets>(requestUrl, _serializerOptions);

		var markets = assetMarkets?.Data?
			.Where(market => market.BaseId == currencyId && market.QuoteSymbol == CoinCapAPI.QuoteSymbol.USD)
			.OrderByDescending(market => market.PriceUsd)
			.ToList();

		return markets;
	}

	public async Task<List<CurrencyModel>?> SearchCurrency(string nameToSearch)
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();

		var requestUrl = string.Format(CoinCapAPI.AssetSearchUrlTemplate, nameToSearch.ToLower());

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
}

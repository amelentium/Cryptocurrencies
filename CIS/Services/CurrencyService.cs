using CIS.Constants;
using CIS.Models;
using CIS.Models.CoinCap;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CIS.Services;

public class CurrencyService : ICurrencyService
{
	private readonly IHttpClientFactory _httpClientFactory;
	public CurrencyService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<List<CurrencyModel>?> GetAssets()
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();
		var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

		var assets = await httpClient.GetFromJsonAsync<AssetsResponse>(CoinCapAPI.AssetsUrl, serializerOptions);

		return assets?.Data;
	}

	public async Task<CurrencyModel?> GetAssetById(string id)
	{
		using HttpClient httpClient = _httpClientFactory.CreateClient();
		var requestUrl = string.Format(CoinCapAPI.AssetsByIdUrlTemplate, id);
		var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

		var asset = await httpClient.GetFromJsonAsync<AssetByIdResponse>(requestUrl, serializerOptions);

		return asset?.Data;
	}
}

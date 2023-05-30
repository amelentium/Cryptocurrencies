namespace CIS.Constants;

public static class CoinCapAPI
{
	private const string _baseUrl = "https://api.coincap.io/v2";

	public const string AssetsUrl = _baseUrl + "/assets";
	public const string AssetsByIdUrlTemplate = AssetsUrl + "/{0}";
	public const string AssetMarketsUrlTemplate = AssetsByIdUrlTemplate + "/markets";

	public static class QuoteSymbol
	{
		public const string USD = "USD";
	}
}

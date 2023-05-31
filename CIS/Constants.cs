namespace CIS;

public static class Constants
{
	public static class CoinCapAPI
	{
		private const string _baseUrl = "https://api.coincap.io/v2";

		public const string AssetsUrl = _baseUrl + "/assets";
		public const string AssetSearchUrlTemplate = AssetsUrl + "?search={0}";
		public const string AssetsByIdUrlTemplate = AssetsUrl + "/{0}";
		public const string AssetMarketsUrlTemplate = AssetsByIdUrlTemplate + "/markets";
		public const string AssetHistoryUrlTemplate = AssetsByIdUrlTemplate + "/history?interval=d1";

		public static class QuoteSymbol
		{
			public const string USD = "USD";
		}
	}

	public static class Font
	{
		public const string Family = "Consolas";
		public const int Size = 16;
	}
}

namespace CIS.Constants;

public static class CoinCapAPI
{
	private const string _baseUrl = "https://api.coincap.io/v2";

	public const string AssetsUrl = _baseUrl + "/assets";
	public const string AssetsByIdUrlTemplate = AssetsUrl + "/{0}";
}

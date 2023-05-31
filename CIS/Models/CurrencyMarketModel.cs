namespace CIS.Models;

public class CurrencyMarketModel : ModelBase
{
	private string? exchangeId;
	private string? baseId;
	private string? quoteId;
	private string? baseSymbol;
	private string? quoteSymbol;
	private double? volumeUsd24Hr;
	private double? priceUsd;
	private double? volumePercent;

	public string? ExchangeId
	{
		get => exchangeId;
		set { exchangeId = value; OnPropertyChanged(nameof(ExchangeId)); }
	}
	public string? BaseId
	{
		get => baseId;
		set { baseId = value; OnPropertyChanged(nameof(BaseId)); }
	}
	public string? QuoteId
	{
		get => quoteId;
		set { quoteId = value; OnPropertyChanged(nameof(QuoteId)); }
	}
	public string? BaseSymbol
	{
		get => baseSymbol;
		set { baseSymbol = value; OnPropertyChanged(nameof(BaseSymbol)); }
	}
	public string? QuoteSymbol
	{
		get => quoteSymbol;
		set { quoteSymbol = value; OnPropertyChanged(nameof(QuoteSymbol)); }
	}
	public double? VolumeUsd24Hr
	{
		get => volumeUsd24Hr;
		set { volumeUsd24Hr = value; OnPropertyChanged(nameof(VolumeUsd24Hr)); }
	}
	public double? PriceUsd
	{
		get => priceUsd;
		set { priceUsd = value; OnPropertyChanged(nameof(PriceUsd)); }
	}
	public double? VolumePercent
	{
		get => volumePercent;
		set { volumePercent = value; OnPropertyChanged(nameof(VolumePercent)); }
	}
}

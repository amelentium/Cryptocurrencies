namespace CIS.Models;

public class CurrencyModel : ModelBase
{
	private string? id;
	private int rank;
	private string? symbol;
	private string? name;
	private double supply;
	private double? maxSupply;
	private double marketCapUsd;
	private double volumeUsd24Hr;
	private double priceUsd;
	private double changePercent24Hr;
	private double? vwap24Hr;

	public string? Id
	{
		get => id;
		set { id = value; OnPropertyChanged(nameof(Id)); }
	}
	public int Rank
	{
		get => rank;
		set { rank = value; OnPropertyChanged(nameof(Rank)); }
	}
	public string? Symbol
	{
		get => symbol;
		set { symbol = value; OnPropertyChanged(nameof(Symbol)); }
	}
	public string? Name
	{
		get => name;
		set { name = value; OnPropertyChanged(nameof(Name)); }
	}
	public double Supply
	{
		get => supply;
		set { supply = value; OnPropertyChanged(nameof(Supply)); }
	}
	public double? MaxSupply
	{
		get => maxSupply;
		set { maxSupply = value; OnPropertyChanged(nameof(MaxSupply)); }
	}
	public double MarketCapUsd
	{
		get => marketCapUsd;
		set { marketCapUsd = value; OnPropertyChanged(nameof(MarketCapUsd)); }
	}
	public double VolumeUsd24Hr
	{
		get => volumeUsd24Hr;
		set { volumeUsd24Hr = value; OnPropertyChanged(nameof(VolumeUsd24Hr)); }
	}
	public double PriceUsd
	{
		get => priceUsd;
		set { priceUsd = value; OnPropertyChanged(nameof(PriceUsd)); }
	}
	public double ChangePercent24Hr
	{
		get => changePercent24Hr;
		set { changePercent24Hr = value; OnPropertyChanged(nameof(ChangePercent24Hr)); }
	}
	public double? Vwap24Hr
	{
		get => vwap24Hr;
		set { vwap24Hr = value; OnPropertyChanged(nameof(Vwap24Hr)); }
	}
}

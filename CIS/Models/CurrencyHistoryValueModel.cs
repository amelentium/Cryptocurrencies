using System;

namespace CIS.Models;

public class CurrencyHistoryValueModel : ModelBase
{
	private DateTime date;
	private ulong time;
	private double priceUsd;

	public DateTime Date
	{
		get => date;
		set { date = value; OnPropertyChanged(nameof(Date)); }
	}

	public ulong Time
	{
		get => time;
		set { time = value; OnPropertyChanged(nameof(Time)); }
	}

	public double PriceUsd
	{
		get => priceUsd;
		set { priceUsd = value; OnPropertyChanged(nameof(PriceUsd)); }
	}
}

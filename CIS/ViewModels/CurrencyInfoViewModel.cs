using CIS.Commands;
using CIS.Models;
using CIS.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CIS.ViewModels;

public class CurrencyInfoViewModel : ViewModelBase
{
	private CurrencyModel? currency;
	private List<CurrencyMarketModel>? currencyMarkets;
	private readonly ICurrencyService _currencyService;
	private PlotModel? historyPlot;

	public ICommand CurrenciesNavigateCommand { get; init; }

	public CurrencyModel? Currency
	{
		get => currency;
		set { currency = value; OnPropertyChanged(nameof(Currency)); }
	}

	public List<CurrencyMarketModel>? CurrencyMarkets
	{
		get => currencyMarkets;
		set { currencyMarkets = value; OnPropertyChanged(nameof(CurrencyMarkets)); }
	}

	public PlotModel? HistoryPlot
	{
		get => historyPlot;
		set { historyPlot = value; OnPropertyChanged(nameof(HistoryPlot)); }
	}

	public CurrencyInfoViewModel(ICurrencyService currencyService, NavigateCommand<CurrenciesViewModel> currenciesNavigateCommand)
	{
		_currencyService = currencyService;
		CurrenciesNavigateCommand = currenciesNavigateCommand;
	}

	public async Task LoadCurrencyData(string currencyId)
	{
		Currency = await _currencyService.GetCurrencyByIdAsync(currencyId);
		CurrencyMarkets = await _currencyService.GetCurrencyMarketsAsync(currencyId);

		await CreateHistoryPlot(currencyId);
	}

	private async Task CreateHistoryPlot(string currencyId)
	{

		var currencyHistory = await _currencyService.GetCurrencyHistoryAsync(currencyId);

		if (currencyHistory == null)
		{
			return;
		}

		var plot = new PlotModel() 
		{ 
			Title = $"{currency?.Name} Price History",
			DefaultFont = Constants.Font.Family,
			TitleFontSize = Constants.Font.Size,
			DefaultFontSize = Constants.Font.Size - 2,
		};

		var series = new FunctionSeries() { TrackerFormatString = "Date: {2:MM.dd}, Price: {4:F4}" };

		foreach (var historyValue in currencyHistory)
		{
			series.Points.Add(new DataPoint(
					DateTimeAxis.ToDouble(historyValue.Date),
					historyValue.PriceUsd));
		}

		plot.Series.Add(series);

		plot.Axes.Add(new DateTimeAxis
		{
			Position = AxisPosition.Bottom,
			MinorIntervalType = DateTimeIntervalType.Days,
			IntervalType = DateTimeIntervalType.Days,
		});

		plot.Axes.Add(new LinearAxis());

		HistoryPlot = plot;
	}
}

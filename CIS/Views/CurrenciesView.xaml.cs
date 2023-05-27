using CIS.Services;
using CIS.ViewModels;
using System.Windows;

namespace CIS.Views
{
	/// <summary>
	/// Interaction logic for CurrencyInfoView.xaml
	/// </summary>
	public partial class CurrenciesView : Window
	{
		public CurrenciesView(ICurrencyService currencyService)
		{
			InitializeComponent();

			DataContext = new CurrenciesViewModel(currencyService);
		}
	}
}

using CIS.Services;
using CIS.ViewModels;
using System.Windows;

namespace CIS.Views
{
	/// <summary>
	/// Interaction logic for CurrencyInfoView.xaml
	/// </summary>
	public partial class CurrencyInfoView : Window
	{
		public CurrencyInfoView(ICurrencyService currencyService)
		{
			InitializeComponent();

			DataContext = new CurrencyInfoViewModel(currencyService);
		}
	}
}

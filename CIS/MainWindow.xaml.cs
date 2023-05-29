using CIS.ViewModels;
using System.Windows;

namespace CIS;

public partial class MainWindow : Window
{
	public MainWindow(MainViewModel viewModel)
	{
		InitializeComponent();

		DataContext = viewModel;
	}
}

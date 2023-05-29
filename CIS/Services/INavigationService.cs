using CIS.ViewModels;

namespace CIS.Services
{
	public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
	{
		void Navigate();
	}
}
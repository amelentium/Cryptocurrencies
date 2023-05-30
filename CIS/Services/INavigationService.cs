using CIS.ViewModels;
using System;

namespace CIS.Services;

public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
{
	void Navigate();

	void Navigate<TAction>(TAction postAction, params object?[]? args) where TAction : Delegate;
}
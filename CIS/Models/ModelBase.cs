﻿using System.ComponentModel;

namespace CIS.Models;

public abstract class ModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;
	protected void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

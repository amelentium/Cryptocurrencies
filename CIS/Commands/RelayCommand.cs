using System;

namespace CIS.Commands;

public class RelayCommand : CommandBase
{
	private readonly Action<object?> _execute;

	public RelayCommand(Action<object?> execute)
	{
		_execute = execute;
	}

	public override void Execute(object? parameter)
	{
		_execute(parameter);
	}
}

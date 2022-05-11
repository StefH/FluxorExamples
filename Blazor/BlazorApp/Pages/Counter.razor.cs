using BlazorApp.Store.CounterUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages;

public partial class Counter
{
	[Inject]
	private IState<CounterState> CounterState { get; set; } = null!;

	[Inject]
	public IDispatcher Dispatcher { get; set; } = null!;

	private void IncrementCount()
	{
		var action = new IncrementCounterAction();
		Dispatcher.Dispatch(action);
	}

	private void SetTo0()
	{
		var action = new SetCounterAction(0);
		Dispatcher.Dispatch(action);
	}

	private void SetTo42()
	{
		var action = new SetCounterAction(42);
		Dispatcher.Dispatch(action);
	}
}
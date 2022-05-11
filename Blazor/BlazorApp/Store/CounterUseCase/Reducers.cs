using Fluxor;

namespace BlazorApp.Store.CounterUseCase;

public static class Reducers
{
	[ReducerMethod(typeof(IncrementCounterAction))]
	public static CounterState ReduceIncrementCounterAction(CounterState state) =>
		new (clickCount: state.ClickCount + 1);

	[ReducerMethod]
	public static CounterState ReduceSetCounterAction(CounterState state, SetCounterAction action) =>
		new(clickCount: action.ClickCount);
}
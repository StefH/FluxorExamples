using Fluxor;

namespace BlazorApp.Store.CounterUseCase;

public static class Reducers
{
	[ReducerMethod]
	public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
		new(clickCount: state.ClickCount + 1);


	// or


	//[ReducerMethod(typeof(IncrementCounterAction))]
	//public static CounterState ReduceIncrementCounterAction(CounterState state) =>
	//	new CounterState(clickCount: state.ClickCount + 1);
}
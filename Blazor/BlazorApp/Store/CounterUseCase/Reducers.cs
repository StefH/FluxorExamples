using Fluxor;

namespace BlazorApp.Store.CounterUseCase;

// Reducers are static methods that take the current state and an action, and return a new state.
public static class Reducers
{
	// The method name doesn't matter, but the signature does. The method must:
	// - Have a [ReducerMethod] attribute
	// - Be public
	// - Be static
	// - Take one parameter: the current state
	// - Return a new state
	[ReducerMethod(typeof(IncrementCounterAction))]
	public static CounterState ReduceIncrementCounterAction(CounterState state) =>
		new (ClickCount: state.ClickCount + 1);



	// The method name doesn't matter, but the signature does. The method must:
	// - Have a [ReducerMethod] attribute
	// - Be public
	// - Be static
	// - Take two parameters: the current state, and the action
	// - Return a new state
	[ReducerMethod]
	public static CounterState ReduceSetCounterAction(CounterState state, SetCounterAction action) =>
		new(ClickCount: action.ClickCount);
}
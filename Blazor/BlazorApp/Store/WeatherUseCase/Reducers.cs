using Fluxor;

namespace BlazorApp.Store.WeatherUseCase;

public static class Reducers
{
	// The method name doesn't matter, but the signature does. The method must:
	// - Have a [ReducerMethod] attribute
	// - Be public
	// - Be static
	// - Take two parameters: the current state, and the action
	// - Return a new state
	[ReducerMethod]
	public static WeatherState ReduceFetchDataAction(WeatherState state, FetchDataAction action) =>
		new(isLoading: true, forecasts: null);



	// The method name doesn't matter, but the signature does. The method must:
	// - Have a [ReducerMethod] attribute
	// - Be public
	// - Be static
	// - Take two parameters: the current state, and the action
	// - Return a new state
	[ReducerMethod]
	public static WeatherState ReduceFetchDataResultAction(WeatherState state, FetchDataResultAction action) =>
		new(isLoading: false, forecasts: action.Forecasts);
}
using BlazorApp.Models;
using Fluxor;

namespace BlazorApp.Store.WeatherUseCase;

[FeatureState]
public record WeatherState
{
	public bool IsLoading { get; }
	public IEnumerable<WeatherForecast> Forecasts { get; }

	// A parameterless constructor is required on state for determining the initial state, and can be private or public.
	private WeatherState() { }

	public WeatherState(bool isLoading, IEnumerable<WeatherForecast>? forecasts)
	{
		IsLoading = isLoading;
		Forecasts = forecasts ?? Array.Empty<WeatherForecast>();
	}
}
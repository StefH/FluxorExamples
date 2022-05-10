using BlazorApp.Models;
using Fluxor;

namespace BlazorApp.Store.WeatherUseCase;

[FeatureState]
public class WeatherState
{
	public bool IsLoading { get; }
	public IEnumerable<WeatherForecast> Forecasts { get; }

	private WeatherState() { }

	public WeatherState(bool isLoading, IEnumerable<WeatherForecast>? forecasts)
	{
		IsLoading = isLoading;
		Forecasts = forecasts ?? Array.Empty<WeatherForecast>();
	}
}
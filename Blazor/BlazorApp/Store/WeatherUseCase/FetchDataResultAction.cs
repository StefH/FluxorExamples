using BlazorApp.Models;

namespace BlazorApp.Store.WeatherUseCase;

public class FetchDataResultAction
{
	public IEnumerable<WeatherForecast> Forecasts { get; }

	public FetchDataResultAction(IEnumerable<WeatherForecast>? forecasts)
	{
		Forecasts = forecasts ?? Array.Empty<WeatherForecast>();
	}
}
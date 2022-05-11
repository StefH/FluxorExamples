using BlazorApp.Models;
using Fluxor;
using System.Net.Http.Json;

namespace BlazorApp.Store.WeatherUseCase;

public class FetchDataEffects
{
	private readonly HttpClient _httpClient;

	public FetchDataEffects(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	[EffectMethod]
	public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher) // , CancellationToken cancellationToken
	{
		await Task.Delay(3000);

		var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
		dispatcher.Dispatch(new FetchDataResultAction(forecasts));
	}
}
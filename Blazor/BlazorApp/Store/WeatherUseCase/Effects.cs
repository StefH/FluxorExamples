using BlazorApp.Models;
using Fluxor;
using System.Net.Http.Json;

namespace BlazorApp.Store.WeatherUseCase;

public class Effects
{
	private readonly HttpClient _httpClient;

	public Effects(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	[EffectMethod]
	public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher) // , CancellationToken cancellationToken
	{
		await Task.Delay(2000);

		var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
		dispatcher.Dispatch(new FetchDataResultAction(forecasts));
	}
}
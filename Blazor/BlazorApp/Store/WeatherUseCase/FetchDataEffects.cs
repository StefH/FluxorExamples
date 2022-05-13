using BlazorApp.Models;
using Fluxor;
using Fluxor.Blazor.Web.Middlewares.Routing;
using System.Net.Http.Json;

namespace BlazorApp.Store.WeatherUseCase;

public class FetchDataEffects
{
	private readonly HttpClient _httpClient;
	private CancellationTokenSource? _tokenSource = new();

	public FetchDataEffects(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	[EffectMethod]
	public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
	{
		Cancel(true);

		await Task.Delay(3000, _tokenSource!.Token);

		var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json", _tokenSource.Token);
		dispatcher.Dispatch(new FetchDataResultAction(forecasts));
	}

	// If anyone navigates anywhere, ensure it's cancelled. Needs FluxorOptions.UseRouting()
	[EffectMethod(typeof(GoAction))]
	public Task HandleGo(IDispatcher _)
	{
		Cancel();

		return Task.CompletedTask;
	}

	private void Cancel(bool createNew = false)
	{
		_tokenSource?.Cancel();
		_tokenSource = createNew ? new CancellationTokenSource() : null;
	}
}
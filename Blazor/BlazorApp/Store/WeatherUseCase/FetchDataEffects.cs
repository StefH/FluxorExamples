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

	// If anyone navigates anywhere, ensure it's cancelled. Needs FluxorOptions.UseRouting()
	// It's possible to use [EffectMethod] without an action parameter.
	// Note that the GoAction is defined in the Fluxor.Blazor.Web.Middlewares.Routing namespace.
	[EffectMethod(typeof(GoAction))]
	public Task HandleGo(IDispatcher _)
	{
		// Cancel any previous request
		Cancel();

		return Task.CompletedTask;
	}

	// If anyone navigates to the FetchData page, fetch the data.
	[EffectMethod]
	public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
	{
		// Cancel any previous request
		Cancel(true);

		// Simulate a long-running operation
		try
		{
			await Task.Delay(3000, _tokenSource!.Token);
		}
		catch (OperationCanceledException)
		{
			Console.WriteLine("The task has been canceled.");
			return;
		}

		var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json", _tokenSource.Token);

		// Dispatch the result, but only if the token has not been cancelled.
		dispatcher.Dispatch(new FetchDataResultAction(forecasts));
	}

	private void Cancel(bool createNew = false)
	{
		_tokenSource?.Cancel();
		_tokenSource = createNew ? new CancellationTokenSource() : null;
	}
}
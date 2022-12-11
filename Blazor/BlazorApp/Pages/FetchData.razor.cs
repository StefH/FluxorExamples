using BlazorApp.Store.WeatherUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages;

public partial class FetchData
{
	[Inject]
	private IState<WeatherState> WeatherState { get; set; } = null!;

	[Inject]
	private IDispatcher Dispatcher { get; set; } = null!;

	protected override void OnInitialized()
	{
		base.OnInitialized();
		Dispatcher.Dispatch(new FetchDataAction());
	}

	private void FetchNewData()
	{
		Dispatcher.Dispatch(new FetchDataAction());
	}
}
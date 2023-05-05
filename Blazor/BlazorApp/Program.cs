using BlazorApp;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluxor(fluxorOptions =>
{
	// Scans the specified assembly for any Fluxor related code (states, reducers, etc).
	fluxorOptions.ScanAssemblies(typeof(Program).Assembly);

	// Registers the Routing Middleware that will be executed after every action dispatched.
	fluxorOptions.UseRouting();

#if DEBUG
	// Registers the Redux DevTools Middleware that will send state changes to the Redux DevTools extension.
	fluxorOptions.UseReduxDevTools();
#endif
});

await builder.Build().RunAsync();
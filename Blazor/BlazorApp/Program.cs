using BlazorApp;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluxor(o =>
{
	o.ScanAssemblies(typeof(Program).Assembly);
	o.UseRouting();

#if DEBUG
	o.UseReduxDevTools();
#endif
});

await builder.Build().RunAsync();
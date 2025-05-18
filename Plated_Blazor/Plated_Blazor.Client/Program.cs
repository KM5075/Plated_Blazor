using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Plated_Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton(sp =>
{
    return new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
});

builder.Services.AddScoped<IApiService, ApiService>();

await builder.Build().RunAsync();

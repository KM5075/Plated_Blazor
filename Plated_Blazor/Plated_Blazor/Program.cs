using Plated_Blazor.Components;
using Plated_Blazor.Data;
using Plated_Blazor.Endpoints;
using Microsoft.EntityFrameworkCore;
using Plated_Blazor.Services;
using Plated_Blazor.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddRazorComponents()
   .AddInteractiveWebAssemblyComponents()
   .AddInteractiveServerComponents();

builder.Services.AddDbContext<Planted_BlazorContext>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("Plated_BlazorContext") ?? throw new InvalidOperationException("Connection string 'Plated_BlazorContext' not found.")));

builder.Services.AddHttpClient();
builder.Services.AddScoped<IApiService, DummyApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapRecipeItemEndpoints();

app.MapStaticAssets();
app.MapRazorComponents<App>()
   .AddInteractiveWebAssemblyRenderMode()
   .AddInteractiveServerRenderMode()
   .AddAdditionalAssemblies(typeof(Plated_Blazor.Client._Imports).Assembly);

app.Run();

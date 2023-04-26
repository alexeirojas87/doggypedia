using DogBreedApp.Client;
using DogBreedApp.Client.Services;
using DogBreedApp.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var configuration = builder.Configuration;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(configuration["ServerApiUrl"] ?? "") });
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddScoped<IDogService, DogService>();

builder.Services.AddMudServices();
await builder.Build().RunAsync();

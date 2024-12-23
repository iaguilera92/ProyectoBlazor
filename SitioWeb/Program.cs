using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SitioWeb;
using Blazored.Modal;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<HttpClient>(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7000/")  // Este es tu servidor base si es necesario
});
// HttpClient para Blazor
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<Principal>();
builder.Services.AddBlazoredModal();
builder.Services.AddHttpClient();

builder.Services.AddScoped<TransbankService>();
await builder.Build().RunAsync();

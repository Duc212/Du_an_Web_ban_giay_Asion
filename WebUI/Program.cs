using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebUI;
using WebUI.Services;
using WebUI.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register Services
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Register Auth Service - will be initialized on first use
builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();

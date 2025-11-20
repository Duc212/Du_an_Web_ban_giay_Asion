using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebUI;
using WebUI.Services;
using WebUI.Services.Interfaces;

public partial class Program
{
    public static IServiceProvider? ServiceProvider { get; set; }

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        // Register Configuration Service first
        builder.Services.AddScoped<ConfigurationService>();

        // Register base HttpClient (without auth)
        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        });

        // Register Auth Service
        builder.Services.AddScoped<IAuthService, AuthService>();

        // Register other Services
        builder.Services.AddScoped<CartService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<OrderService>();
        builder.Services.AddScoped<IPaymentService, PaymentService>();
        builder.Services.AddScoped<RecentlyViewedService>();
        builder.Services.AddScoped<VoucherService>();

        // Register Google Auth Service
        builder.Services.AddScoped<GoogleAuthService>();

        // Register Loading Service
        builder.Services.AddScoped<ILoadingService, LoadingService>();

        // Register Toast Service
        builder.Services.AddSingleton<IToastService, ToastService>();

        var host = builder.Build();
        ServiceProvider = host.Services;
        await host.RunAsync();
    }
}

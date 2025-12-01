using AdminWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AdminWeb.Services;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Đăng ký Authentication
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

// Tạo HttpMessageHandler tự động thêm token
builder.Services.AddScoped<AuthorizationMessageHandler>();

// Cấu hình HttpClient với token handler
builder.Services.AddHttpClient<ProductService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<BrandService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<CategoryService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<UserService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<OrderService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<VoucherService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<ShippingService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<ColorService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<SizeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
});

builder.Services.AddHttpClient<ColorService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<SizeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddScoped<ToastService>();

await builder.Build().RunAsync();

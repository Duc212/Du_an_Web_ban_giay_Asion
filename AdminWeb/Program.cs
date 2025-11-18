using AdminWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AdminWeb.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Cấu hình HttpClient cho AdminWeb API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7134/") });

// Đăng ký dịch vụ giả lập đơn hàng & toast
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<UserService>();

// Nếu cần sử dụng API base URL từ cấu hình
// builder.Services.AddHttpClient<ProductService>(client =>
// {
//     client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
// });

await builder.Build().RunAsync();

using API.Extensions;
using BUS.Service;
using BUS.Services;
using BUS.Services.Interfaces;
using DAL;
using DAL.Repositories;
using DAL.Repository;
using DAL.RepositoryAsyns;
using DAL.UnitOfWork;
using Helper.CacheCore;
using Helper.CacheCore.Interfaces;
using Helper.ModelHelps;
using Helper.Utils;
using Helper.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0.0",
        Title = "My Project API",
        Description = "API documentation for My Project"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

builder.Services.AddTransient<IOrderServices, OrderServices>();
builder.Services.AddTransient<IAuthServices, AuthServices>();
builder.Services.AddTransient<ITokenUtils, TokenUtils>();
builder.Services.AddTransient<IMailServices, MailServices>();
builder.Services.AddTransient<IAvatarUtils, AvatarUtils>();
builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<ICartServices, CartServices>();
builder.Services.AddTransient<IPaymentServices, PaymentServices>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddMemoryCache(); 
builder.Services.AddSingleton<IMemoryCacheSystem, MemoryCacheSystem>();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var serviceProvider = builder.Services.BuildServiceProvider();
var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
HttpContextHelper.Configure(httpContextAccessor);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseSession(); 
app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

CryptoHelperUtil.Init(builder.Configuration);
app.Run();

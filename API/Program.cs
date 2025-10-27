using BUS.Services;
using BUS.Services.Interfaces;
using BUS.Service;
using DAL;
using DAL.Repository;
using DAL.RepositoryAsyns;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

builder.Services.AddTransient<IOrderServices, OrderServices>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

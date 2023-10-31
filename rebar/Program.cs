using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rebar.Models;
using rebar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//service to Order
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("RebarStoreDtabaseSetting"));
builder.Services.AddTransient<IOrderService, OrderService>();

//service to Shake
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("RebarStoreDtabaseSetting"));//meybe to remove
builder.Services.AddTransient<IShakeService, ShakeService>();

//service to Account
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("RebarStoreDtabaseSetting"));//meybe to remove
builder.Services.AddTransient<IAccountService, AccountService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

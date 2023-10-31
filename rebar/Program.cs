using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rebar.Models;
using rebar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//service to Shake
builder.Services.Configure<ShakeDatabaseSettings>(
    builder.Configuration.GetSection(nameof(ShakeDatabaseSettings)));
builder.Services.AddSingleton<IShakeDatabaseSettings>(sp => 
    sp.GetRequiredService<IOptions<ShakeDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(
    builder.Configuration.GetValue<string>("ShakeStoreDtabaseSetting:ConnecionString")));

//service to Order
builder.Services.Configure<OrderDatabaseSettings>(
    builder.Configuration.GetSection(nameof(OrderDatabaseSettings)));
builder.Services.AddSingleton<IOrderDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<OrderDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(
    builder.Configuration.GetValue<string>("OrderStoreDtabaseSetting:ConnecionString")));

//service to Account
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("RebarStoreDtabaseSetting"));
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

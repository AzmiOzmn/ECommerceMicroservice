using ECommerce.Basket.Services;
using ECommerce.Basket.Services.BasketServices;
using ECommerce.Basket.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection(nameof(RedisSettings)));
builder.Services.AddScoped<IBasketService, BasketService>();

builder.Services.AddSingleton<RedisService>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redisService = new RedisService(settings.Port, settings.Host);
    redisService.Connect();
    return redisService;
});
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

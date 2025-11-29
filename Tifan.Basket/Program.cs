using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Tifan.Basket.Infra;
using Tifan.Basket.IServices;
using Tifan.Basket.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

MapsterConfig.RegisterMappings();

builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
builder.Services.AddSingleton<IMapper , ServiceMapper>();
builder.Services.AddTransient<IBasketService, BasketService>();

builder.Services.AddDbContext<BasketDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TifanBasketDatabase")
    ));

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

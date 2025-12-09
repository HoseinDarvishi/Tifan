using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Tifan.Order.Infra;
using Tifan.Order.IServices;
using Tifan.Order.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMapster();
builder.Services.AddSwaggerGen();

MapsterConfig.RegisterMappings();

builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
builder.Services.AddSingleton<IMapper, ServiceMapper>();

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TifanOrderDatabase")
    ));

builder.Services.AddTransient<IOrderService, OrderService>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("map");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

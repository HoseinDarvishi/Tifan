using Mapster;
using Microsoft.EntityFrameworkCore;
using Tifan.Discount.Infra;
using Tifan.Discount.IServices;
using Tifan.Discount.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMapster();
builder.Services.AddSwaggerGen();

MapsterConfig.RegisterMappings();

builder.Services.AddDbContext<DiscountDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TifanDiscountDatabase")
    ));

builder.Services.AddTransient<IDiscountService, DiscountService>();

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

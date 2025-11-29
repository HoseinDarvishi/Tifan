using Microsoft.EntityFrameworkCore;
using TifanBasket.Models;

namespace Tifan.Basket.Infra;

public class BasketDbContext : DbContext
{
    public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
    {

    }

    public DbSet<TifanBasket.Models.Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

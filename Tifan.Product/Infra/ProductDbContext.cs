using Microsoft.EntityFrameworkCore;

namespace Tifan.Product.Infra;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
        
    }

    public DbSet<Models.Product> Products { get;set; }
    public DbSet<Models.Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
    }
}

using Microsoft.EntityFrameworkCore;
using Tifan.Discount.Models;

namespace Tifan.Discount.Infra;

public class DiscountDbContext : DbContext
{
    public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
    { }

    public DbSet<DiscountCode> Discounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    } 
}
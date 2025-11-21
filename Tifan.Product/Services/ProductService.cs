using Microsoft.EntityFrameworkCore;
using Tifan.Product.Infra;
using Tifan.Product.IServices;

namespace Tifan.Product.Services
{
    public class ProductService(ProductDbContext context) : IProductService
    {
        public async Task<Models.Product> GetAsync(Guid id , CancellationToken ct)
            => await context.Products.FindAsync(id,ct);

        public async Task<List<Models.Product>> GetAllAsync(CancellationToken ct)
            => await context.Products.ToListAsync(ct);

        public async Task AddAsync(Models.Product product)
            => await context.AddAsync(product);

        public void Update(Models.Product product)
            => context.Update(product);

        public async Task RemoveAsync(Guid id)
            => await context.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}

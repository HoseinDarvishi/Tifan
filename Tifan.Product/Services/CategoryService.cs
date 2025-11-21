using Microsoft.EntityFrameworkCore;
using Tifan.Product.Infra;
using Tifan.Product.IServices;
using Tifan.Product.Models;

namespace Tifan.Product.Services
{
    public class CategoryService(ProductDbContext context) : ICategoryService
    {
        public async Task<Category> GetAsync(Guid id, CancellationToken ct)
            => await context.Categories.FindAsync(id, ct);

        public async Task<List<Category>> GetAllAsync(CancellationToken ct)
            => await context.Categories.ToListAsync(ct);

        public async Task AddAsync(Category category)
            => await context.AddAsync(category);

        public void Update(Category category)
            => context.Update(category);

        public async Task RemoveAsync(Guid id)
            => await context.Categories.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}

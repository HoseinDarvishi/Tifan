using Mapster;
using Microsoft.EntityFrameworkCore;
using Tifan.Product.Infra;
using Tifan.Product.IServices;
using Tifan.Product.Models;
using Tifan.Product.Wrappers.Category;

namespace Tifan.Product.Services;

public class CategoryService(ProductDbContext context) : ICategoryService
{
    public async Task<CategoryVM> GetAsync(Guid id, CancellationToken ct)
        => await context.Categories
            .AsNoTracking()
            .Where(x=>x.Id ==  id)
            .ProjectToType<CategoryVM>()
            .FirstOrDefaultAsync(x=> x.Id == id , ct);

    public async Task<List<CategoryVM>> GetAllAsync(CancellationToken ct)
        => await context.Categories
            .AsNoTracking()
            .ProjectToType<CategoryVM>()
            .ToListAsync(ct);

    public async Task<Guid> AddAsync(CreateCategory category)
    {
        var model = new Category(category.Name , category.Description);
        await context.AddAsync(model);
        await context.SaveChangesAsync();
        return model.Id;
    }

    public async Task UpdateAsync(EditCategory category)
    {
        var model = await context.Categories.FindAsync(category.Id);
        model.Edit(category.Name, category.Description);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
        => await context.Categories.Where(x => x.Id == id).ExecuteDeleteAsync();
}
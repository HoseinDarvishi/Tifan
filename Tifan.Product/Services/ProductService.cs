using Mapster;
using Microsoft.EntityFrameworkCore;
using Tifan.Product.Infra;
using Tifan.Product.IServices;
using Tifan.Product.Wrappers.Product;

namespace Tifan.Product.Services;

public class ProductService(ProductDbContext context) : IProductService
{
    public async Task<ProductVM> GetAsync(Guid id, CancellationToken ct)
        => await context.Products
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(x=>x.Category)
            .ProjectToType<ProductVM>()
            .FirstOrDefaultAsync(ct);

    public async Task<List<ProductVM>> GetAllAsync(CancellationToken ct)
        => await context.Products
            .AsNoTracking()
            .Include(x=>x.Category)
            .ProjectToType<ProductVM>()
            .ToListAsync(ct);

    public async Task<Guid> AddAsync(CreateProduct p)
    {
        var model = new Models.Product(p.Name, p.Description, p.Image, p.Price, p.CategoryId);
        await context.AddAsync(model);
        await context.SaveChangesAsync();
        return model.Id;
    }

    public async Task UpdateAsync(EditProduct product)
    {
        var model = await context.Products.FindAsync(product.Id);
        model.Edit(model.Name, model.Description, model.Image, model.Price, model.CategoryId);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
        => await context.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
}

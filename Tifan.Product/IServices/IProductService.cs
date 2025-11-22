
using Tifan.Product.Wrappers.Product;

namespace Tifan.Product.IServices;

public interface IProductService
{
    Task<Guid> AddAsync(CreateProduct p);
    Task<List<ProductVM>> GetAllAsync(CancellationToken ct);
    Task<ProductVM> GetAsync(Guid id, CancellationToken ct);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(EditProduct product);
}

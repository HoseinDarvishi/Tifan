using Tifan.Product.Models;
using Tifan.Product.Wrappers.Category;

namespace Tifan.Product.IServices;

public interface ICategoryService
{
    Task<Guid> AddAsync(CreateCategory category);
    Task<List<CategoryVM>> GetAllAsync(CancellationToken ct);
    Task<CategoryVM> GetAsync(Guid id, CancellationToken ct);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(EditCategory category);
}

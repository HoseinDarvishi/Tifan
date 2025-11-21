using Tifan.Product.Models;

namespace Tifan.Product.IServices
{
    public interface ICategoryService
    {
        Task AddAsync(Category category);
        Task<List<Category>> GetAllAsync(CancellationToken ct);
        Task<Category> GetAsync(Guid id, CancellationToken ct);
        Task RemoveAsync(Guid id);
        void Update(Category category);
    }
}

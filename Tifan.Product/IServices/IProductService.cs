
namespace Tifan.Product.IServices
{
    public interface IProductService
    {
        Task AddAsync(Models.Product product);
        Task<List<Models.Product>> GetAllAsync(CancellationToken ct);
        Task<Models.Product> GetAsync(Guid id, CancellationToken ct);
        Task RemoveAsync(Guid id);
        void Update(Models.Product product);
    }
}

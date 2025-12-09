using Tifan.Order.Wrappers;

namespace Tifan.Order.IServices;

public interface IOrderService
{
    Task AddAsync(AddOrder order, CancellationToken ct = default);
    Task AddOrderItemAsync(AddOrderItem item, CancellationToken ct = default);
    Task ClearOrderAsync(Guid orderId, CancellationToken ct = default);
    Task<List<OrderVM>> GetAllAsync(CancellationToken ct = default);
    Task<List<OrderVM>> GetAllAsync(string userId, CancellationToken ct = default);
    Task<OrderVM> GetAsync(Guid orderId, CancellationToken ct = default);
    Task PayOrderAsync(Guid orderId, CancellationToken ct = default);
    Task RemoveOrderItemAsync(Guid orderItemId, CancellationToken ct = default);
    Task SetItemQuantityAsync(ChangeItemQuantity change, CancellationToken ct = default);
}

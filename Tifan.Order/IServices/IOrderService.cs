using Tifan.Order.Wrappers;

namespace Tifan.Order.IServices;

public interface IOrderService
{
    Task AddAsync(AddOrder order, CancellationToken ct = default);
    Task AddOrderItemAsync(AddOrderItem item, CancellationToken ct = default);
    Task ClearOrderAsync(string userId, CancellationToken ct = default);
    Task RemoveOrderItemAsync(Guid orderItemId, CancellationToken ct = default);
    Task SetItemQuantityAsync(ChangeItemQuantity change, CancellationToken ct = default);
}

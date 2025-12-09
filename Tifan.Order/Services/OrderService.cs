using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Tifan.Order.Infra;
using Tifan.Order.IServices;
using Tifan.Order.Models;
using Tifan.Order.Wrappers;

namespace Tifan.Order.Services
{
    public class OrderService(OrderDbContext context, IMapper mapper) : IOrderService
    {
        public async Task AddAsync(AddOrder order, CancellationToken ct = default)
        {
            var newOrder = mapper.Map<Models.Order>(order);
            await context.AddAsync(order, ct);
            await context.SaveChangesAsync(ct);
        }

        public async Task AddOrderItemAsync(AddOrderItem item, CancellationToken ct = default)
        {
            var orderItem = mapper.Map<OrderItem>(item);
            await context.AddAsync(item, ct);
            await context.SaveChangesAsync(ct);
        }

        public async Task RemoveOrderItemAsync(Guid orderItemId, CancellationToken ct = default)
            => await context.OrderItems.Where(x => x.Id == orderItemId).ExecuteDeleteAsync(ct);

        public async Task ClearOrderAsync(string userId, CancellationToken ct = default)
            => await context.Orders.Where(x => x.UserId == userId).ExecuteDeleteAsync(ct);

        public async Task SetItemQuantityAsync(ChangeItemQuantity change , CancellationToken ct = default)
        {
            var item = await context.OrderItems.FindAsync(change.OrderItemId, ct);
            item.SetQuantity(change.Quantity);
            await context.SaveChangesAsync(ct);
        }
    }
}
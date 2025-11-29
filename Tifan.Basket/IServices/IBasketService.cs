using Tifan.Basket.Wrappers;

namespace Tifan.Basket.IServices;

public interface IBasketService
{
    Task AddItemToBasketAsync(AddItemToBasket item, CancellationToken ct = default);
    Task<BasketVM> GetAsync(string userId, CancellationToken ct = default);
    Task<BasketVM> GetOrCreateBasketAsync(string userId, CancellationToken ct = default);
    Task<bool> RemoveItemFromBasketAsync(Guid itemId, CancellationToken ct = default);
    Task SetQuantityAsync(Guid itemId, int quantity, CancellationToken ct = default);
    Task TransferBasket(string anonymousId, string userId, CancellationToken ct = default);
}

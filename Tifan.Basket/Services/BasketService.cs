using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Tifan.Basket.Infra;
using Tifan.Basket.IServices;
using Tifan.Basket.Wrappers;
using TifanBasket.Models;

namespace Tifan.Basket.Services;

public class BasketService(BasketDbContext context, IMapper mapper) : IBasketService
{
    public async Task<BasketVM> GetOrCreateBasketAsync(string userId , CancellationToken ct = default)
    {
        var basket = await context.Baskets
            .Include(x => x.Items)
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync(ct);

        if (basket == null)
        {
            basket = Create(userId);
            await context.Baskets.AddAsync(basket);
            await context.SaveChangesAsync(ct);
        }

        return mapper.Map<BasketVM>(basket);
    }

    public async Task<BasketVM> GetAsync(string userId, CancellationToken ct = default)
        => await context.Baskets
            .Include(x => x.Items)
            .Where(x=>x.UserId == userId)
            .ProjectToType<BasketVM>()
            .FirstOrDefaultAsync(ct);


    public async Task AddItemToBasketAsync(AddItemToBasket item , CancellationToken ct = default)
    {
        var basket = await context.Baskets.FindAsync(item.BasketId, ct);
        if (basket == null) throw new Exception("Basket Not Found ... !");
        var basketItem = new BasketItem(item.BasketId, item.ProductId, item.ProductName, item.UnitPrice, item.Quantity, item.ImageUrl);
        await context.BasketItems.AddAsync(basketItem, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task<bool> RemoveItemFromBasketAsync(Guid itemId , CancellationToken ct = default)
        => (await context.BasketItems.Where(x=>x.Id == itemId).ExecuteDeleteAsync(ct)) > 0;


    public async Task SetQuantityAsync(Guid itemId , int quantity , CancellationToken ct = default)
    {
        var item = await context.BasketItems.FindAsync(itemId, ct);
        if (item == null) throw new Exception("Basket Item Not Found ... !");
        item.SetQuantity(quantity);
        await context.SaveChangesAsync(ct);
    }

    public async Task TransferBasket(string anonymousId, string userId , CancellationToken ct = default)
    {
        var anonymousBasket = await context.Baskets
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.UserId == anonymousId, ct);

        if (anonymousBasket == null) return;

        var userBasket = await context.Baskets
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.UserId == userId, ct);

        if(userBasket == null)
        {
            userBasket = new TifanBasket.Models.Basket(userId);
            await context.Baskets.AddAsync(userBasket, ct);
        }

        userBasket.AddItem(anonymousBasket.Items);
        context.Remove(anonymousBasket);
        await context.SaveChangesAsync(ct);
    }

    private TifanBasket.Models.Basket Create(string userId)
        => new TifanBasket.Models.Basket(userId);
}
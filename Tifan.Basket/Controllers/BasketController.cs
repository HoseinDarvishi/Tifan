using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tifan.Basket.IServices;
using Tifan.Basket.Wrappers;

namespace Tifan.Basket.Controllers;

[Route("Tifan/Api/[controller]")]
[ApiController]
public class BasketController(IBasketService service) : Controller
{
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetBasket(string userId , CancellationToken ct)
    {
        var basket = await service.GetOrCreateBasketAsync(userId, ct);
        return Ok(basket);
    }

    [HttpPut("{itemId:guid}")]
    public async Task<IActionResult> SetQuantity(Guid itemId , int quantity , CancellationToken ct)
    {
        await service.SetQuantityAsync(itemId, quantity, ct);
        return Ok();
    }

    [HttpDelete("Item/{itemId:guid}")]
    public async Task<IActionResult> RemoveItem(Guid itemId , CancellationToken ct)
    {
        await service.RemoveItemFromBasketAsync(itemId, ct);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(AddItemToBasket item , CancellationToken ct)
    {
        await service.AddItemToBasketAsync(item, ct);
        return Ok();
    }
}

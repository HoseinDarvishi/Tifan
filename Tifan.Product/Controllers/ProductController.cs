using Microsoft.AspNetCore.Mvc;
using Tifan.Product.IServices;
using Tifan.Product.Wrappers.Product;

namespace Tifan.Product.Controllers;

[Route("Tifan/Api/[Product]")]
[ApiController]
public class ProductController(IProductService _service) : Controller
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken ct)
    {
        var product = await _service.GetAsync(id, ct);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var products = await _service.GetAllAsync(ct);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProduct product)
    {
        var productId = await _service.AddAsync(product);
        return Ok(productId);
    }

    [HttpPatch]
    public async Task<IActionResult> Edit([FromBody] EditProduct product)
    {
        await _service.UpdateAsync(product);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(Guid id)
    {
        await _service.RemoveAsync(id);
        return Ok();
    }
}
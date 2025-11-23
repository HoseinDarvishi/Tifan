using Microsoft.AspNetCore.Mvc;
using Tifan.Product.IServices;
using Tifan.Product.Wrappers.Category;

namespace Tifan.Product.Controllers;

[Route("Tifan/Api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService _service) : Controller
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id , CancellationToken ct)
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
    public async Task<IActionResult> Add(CreateCategory category)
    {
        var categoryId = await _service.AddAsync(category);
        return Ok(categoryId);
    }

    [HttpPatch]
    public async Task<IActionResult> Edit(EditCategory category)
    {
        await _service.UpdateAsync(category);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(Guid id) 
    {
        await _service.RemoveAsync(id);
        return Ok();
    }
}

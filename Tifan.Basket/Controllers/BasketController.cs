using Microsoft.AspNetCore.Mvc;

namespace Tifan.Basket.Controllers;

[Route("Tifan/Api/[controller]")]
[ApiController]
public class BasketController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

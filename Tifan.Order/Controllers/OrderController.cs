using Microsoft.AspNetCore.Mvc;
using Tifan.Order.IServices;

namespace Tifan.Order.Controllers
{
    [ApiController]
    [Route("Tifan/Api/[controller]")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        
    }
}
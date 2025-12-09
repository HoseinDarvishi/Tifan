using Microsoft.AspNetCore.Mvc;
using Tifan.Order.IServices;
using Tifan.Order.Wrappers;

namespace Tifan.Order.Controllers
{
    [ApiController]
    [Route("Tifan/Api/[controller]")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var orders = await orderService.GetAllAsync(ct);
            return Ok(orders);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId , CancellationToken ct)
        {
            var orders = await orderService.GetAllAsync(userId, ct);
            return Ok(orders);
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> Get(Guid orderId  , CancellationToken ct)
        {
            var order = await orderService.GetAsync(orderId, ct);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddOrder order)
        {
            await orderService.AddAsync(order);
            return Ok();
        }

        [HttpPost("AddOrderItem")]
        public async Task<IActionResult> AddItem([FromBody] AddOrderItem item)
        {
            await orderService.AddOrderItemAsync(item);
            return Ok();
        }

        [HttpPut("Pay/{orderId:guid}")]
        public async Task<IActionResult> PayOrder(Guid orderId)
        {
            await orderService.PayOrderAsync(orderId);
            return Ok();
        }

        [HttpPatch("Clear/{orderId:guid}")]
        public async Task<IActionResult> Clear(Guid orderId,CancellationToken ct)
        {
            await orderService.ClearOrderAsync(orderId, ct);
            return Ok();
        }
    }
}
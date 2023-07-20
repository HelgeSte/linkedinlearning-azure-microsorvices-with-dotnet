using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/Orders")]
    public class OrdersController : ControllerBase
    {
        private IOrdersProvider ordersProvider;

        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await ordersProvider.GetOrdersAsync();
            if(result.isSuccess)
            {
                return Ok(result.orders);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var result = await ordersProvider.GetOrderAsync(id);
            if(result.isSuccess)
            {
                return Ok(result.order);
            }
            return NotFound();
        }
    }
}

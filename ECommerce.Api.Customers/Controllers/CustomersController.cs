using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customerProvider;
        public CustomersController(ICustomersProvider customerProvider)
        {
            this.customerProvider = customerProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customerProvider.GetCustomerAsync(id);
            if (result.isSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
            
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customerProvider.GetCustomersAsync();
            if (result.isSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }
    }
}

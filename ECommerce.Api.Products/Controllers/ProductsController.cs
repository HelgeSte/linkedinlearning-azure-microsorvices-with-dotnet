using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Controllers
{
    /* In ASP.net core, all the controllers have to inherit from ControllerBase class which is part of 
     * the Microsoft.AspNetCore.MVC namespace, ... */
    [ApiController] // ..., and we're going to decorate this class with the ApiController attribute.*/
    [Route("api/Products")]
    public class ProductsController : ControllerBase    
    {
        /* We need to inject the IProductsProvider object in the constructor of this class. IProductsProvider. 
         * We're going to put this in a private readonly field because we want to use it right here. */
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;            
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await productsProvider.GetProductsAsync();
            if(result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productsProvider.GetProductAsync(id);
            if(result.IsSuccess) // Why is await is needed for isSuccess?
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}

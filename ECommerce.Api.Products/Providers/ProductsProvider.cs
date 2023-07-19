using AutoMapper;
using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext dbContext;
        private readonly ILogger<ProductsProvider> logger;
        private readonly IMapper mapper;

        public ProductsProvider(ProductsDbContext DbContext, ILogger<ProductsProvider> logger, IMapper mapper) 
        {
            this.dbContext = DbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if(!dbContext.Products.Any()) {
                dbContext.Products.Add(new Db.Product() { Id = 1, Name = "Keyboard", Price = 20, Inventory = 100 });
                dbContext.Products.Add(new Db.Product() { Id = 2, Name = "Mouse", Price = 5, Inventory = 200  });
                dbContext.Products.Add(new Db.Product() { Id = 3, Name = "Monitor", Price = 150, Inventory = 1000 });
                dbContext.Products.Add(new Db.Product() { Id = 4, Name = "CPU", Price = 200, Inventory = 2000 });
                dbContext.SaveChanges();
            }
        }


        public async Task<(bool isSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await dbContext.Products.ToListAsync();
                /* Next I want to verify if we have something inside this variable. In which case we're going to map
                 * these Ienumerable of type "Db.product" to Ienumerable of type "models.product".
                 * This is because we're returning this kind of object inside this GetProductsAsync method. So we're
                 * going to do that by invoking the map generic method from auto mapper and the first thing I need to
                 * do is to specify the source type and this is the Db.Product.*/
                if (products != null && products.Any())
                {
                    // Mapping Db.Product to Models.Prodct
                    var result = mapper.Map<IEnumerable<Db.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null); // Success = true, IEnumerable<Models.Product> = result, Error Msg = null
                }
                return (false, null, "Not Found"); // Success = false, IEnumerable<Models.Product> = null, Error msg = "Not Found"
            }
            catch (Exception ex)
            {   // It's always a great idea to log things out so we can see what's going on inside our microservices. 
                logger?.LogError(ex.ToString()); 
                return (false, null, ex.Message); // Return exeption message
            }
        }

        public async Task<(bool isSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int id)
        {

            try
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    // Mapping Db.Product to Models.Prodct
                    var result = mapper.Map<Db.Product, Models.Product>(product);
                    return (true, result, null); // Success = true, IEnumerable<Models.Product> = result, Error Msg = null
                }
                return (false, null, "Not Found"); // Success = false, IEnumerable<Models.Product> = null, Error msg = "Not Found"
            }
            catch (Exception ex)
            {   // It's always a great idea to log things out so we can see what's going on inside our microservices. 
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message); // Return exeption message
            }
        }
    }
}

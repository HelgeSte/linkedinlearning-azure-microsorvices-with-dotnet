using ECommerce.Api.Search.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersService ordersService;
        private readonly IProductsService productService;

        public SearchService(IOrdersService ordersService, IProductsService productService)
        {
            this.ordersService = ordersService;
            this.productService = productService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
            var ordersResult = await ordersService.GetOrdersAsync(customerId);
            var productsResult = await productService.GetProductsAsync();
            foreach(var order in ordersResult.Orders)
            {
                foreach (var item in order.Items)
                {
                    item.ProductName = productsResult.IsSuccess ?
                        item.ProductName = productsResult.Products.FirstOrDefault(p => p.Id == item.ProductId)?.Name : // name only
                        "Product information is not available";
                }
            }
            if (ordersResult.IsSuccess)
            {
                var result = new
                {
                    Orders = ordersResult.Orders
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}

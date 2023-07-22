using ECommerce.Api.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interfaces
{
    /* This will have all the abstractions required to communicate to the orders microservice */
    public interface IOrdersService
    {
        // For communicating with the Orders microservice
        Task<(bool IsSuccess, IEnumerable<Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}

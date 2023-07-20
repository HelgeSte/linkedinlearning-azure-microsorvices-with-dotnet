using ECommerce.Api.Orders.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        Task<(bool isSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync();
        Task<(bool isSuccess, Order order, string ErrorMessage)> GetOrderAsync(int id);
    }
}

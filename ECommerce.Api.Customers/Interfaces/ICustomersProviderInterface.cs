using ECommerce.Api.Customers.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Interfaces
{
    public interface ICustomersProviderInterface
    {
        Task<(bool isSuccess, IEnumerable<Customer> Customers, string ErrorMessage)> GetCustomersAsync();
        Task<(bool isSuccess, Customer Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}

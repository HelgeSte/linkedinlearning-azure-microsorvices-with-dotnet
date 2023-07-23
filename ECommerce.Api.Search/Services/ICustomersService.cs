using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public interface ICustomersService
    {
        Task<(bool IsSuccess, dynamic Customer, string ErrorMessage)> GetCustomerAsync(int customerId);
    }
}

using System.Collections.Generic;

namespace ECommerce.Api.Search.Models
{
    public class Order
    {
        public int Id { get; set; }
        // public int CustomerId { get; set; } // Not used in this project
        public string OrderDate { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}

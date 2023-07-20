using System.Collections.Generic;

namespace ECommerce.Api.Orders.Db
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
        public decimal? Total { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}

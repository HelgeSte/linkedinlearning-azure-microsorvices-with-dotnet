//using ECommerce.Api.Customers.Models;
namespace ECommerce.Api.Orders.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        /* Here, I have the order and the order item entity classes. As you can see inside order, I have these 
         * items property that is of type list of type order item. This is different than the order, and order 
         * item models. Because in the order item model, I don't need to use the order ID. This is just one small 
         * example of the benefits of exposing a model, rather than the entities in this providers.  */
        //public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

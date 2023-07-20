namespace ECommerce.Api.Orders.Db
{
    public class OrderItem
    {
        public int Id { get; set; }
        // Note, OrderId is needed in the Db.OrderItem class, but not in the Models.OrderItem class.
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

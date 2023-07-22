namespace ECommerce.Api.Search.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } // Additional property in the Search project
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

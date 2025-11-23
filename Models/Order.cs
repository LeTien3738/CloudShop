namespace PhoneStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Processing, Shipped, Delivered, Cancelled
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }
        
        // Navigation property
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}

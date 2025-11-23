namespace PhoneStore.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PhoneId { get; set; }
        public string PhoneName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        
        // Navigation properties
        public Order Order { get; set; } = null!;
        public Phone Phone { get; set; } = null!;
    }
}

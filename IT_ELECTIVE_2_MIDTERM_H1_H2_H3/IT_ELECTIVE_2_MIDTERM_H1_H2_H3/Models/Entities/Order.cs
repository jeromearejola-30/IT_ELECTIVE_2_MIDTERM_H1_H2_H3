namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities
{
    public class Order
    {
        public string OrderId { get; set; } = Guid.NewGuid().ToString()[..8].ToUpper();
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItem> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(i => i.TotalPrice);
    }
}
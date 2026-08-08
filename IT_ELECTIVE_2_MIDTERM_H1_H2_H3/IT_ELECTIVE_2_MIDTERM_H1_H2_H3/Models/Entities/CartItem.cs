namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities
{
    public class CartItem
    {
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }
}
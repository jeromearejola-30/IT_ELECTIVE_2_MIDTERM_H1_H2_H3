namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new();

       
        public decimal GrandTotal => Items.Sum(i => i.TotalPrice);

      
        public decimal TotalAmount => GrandTotal;
    }
}
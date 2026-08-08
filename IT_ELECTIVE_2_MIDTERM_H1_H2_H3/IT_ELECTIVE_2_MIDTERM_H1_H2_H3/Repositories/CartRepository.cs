using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories
{
    public class CartRepository
    {
        private readonly ShoppingCart _cart = new();

        public ShoppingCart GetCart() => _cart;

        public void AddItem(Product product, int quantity)
        {
            var existingItem = _cart.Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cart.Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    _cart.Items.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
            }
        }

        public void RemoveItem(int productId)
        {
            _cart.Items.RemoveAll(i => i.Product.Id == productId);
        }
    }
}
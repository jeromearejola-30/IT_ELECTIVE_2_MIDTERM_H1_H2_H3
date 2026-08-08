using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories
{
    public class CartRepository
    {
        private readonly ShoppingCart _cart = new();

        public ShoppingCart GetCart() => _cart;

        public void AddToCart(Product product, int quantity)
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

        // Method aliases in case other actions call AddItem
        public void AddItem(Product product, int quantity) => AddToCart(product, quantity);

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    RemoveFromCart(productId);
                }
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                _cart.Items.Remove(item);
            }
        }

        // Method aliases in case other actions call Remove or RemoveItem
        public void RemoveItem(int productId) => RemoveFromCart(productId);
        public void Remove(int productId) => RemoveFromCart(productId);

        public void Clear()
        {
            _cart.Items.Clear();
        }
    }
}
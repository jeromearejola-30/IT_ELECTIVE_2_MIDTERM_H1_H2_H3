using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Mechanical Gaming Keyboard", Price = 89.99m, StockQuantity = 15 },
            new Product { Id = 2, Name = "Wireless Ergonomic Mouse", Price = 49.99m, StockQuantity = 20 },
            new Product { Id = 3, Name = "27-inch 144Hz Gaming Monitor", Price = 249.99m, StockQuantity = 5 },
            new Product { Id = 4, Name = "RGB Noise-Canceling Headset", Price = 79.99m, StockQuantity = 12 },
            new Product { Id = 5, Name = "USB-C Multi-Port Hub Adapter", Price = 29.99m, StockQuantity = 30 },
            new Product { Id = 6, Name = "Streamer USB Condenser Mic", Price = 69.99m, StockQuantity = 0 }, // Out of stock
            new Product { Id = 7, Name = "HD 1080p Web Camera", Price = 59.99m, StockQuantity = 8 },
            new Product { Id = 8, Name = "XL Gaming Mouse Pad", Price = 19.99m, StockQuantity = 25 }
        };

        public List<Product> GetAllProducts() => _products;

        public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public bool DeductStock(int productId, int quantity)
        {
            var product = GetProductById(productId);
            if (product != null && product.StockQuantity >= quantity)
            {
                product.StockQuantity -= quantity;
                return true;
            }
            return false;
        }
    }
}
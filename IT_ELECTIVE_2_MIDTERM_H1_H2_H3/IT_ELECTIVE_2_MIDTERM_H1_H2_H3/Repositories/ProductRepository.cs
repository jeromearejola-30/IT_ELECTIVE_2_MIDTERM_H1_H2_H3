using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Mechanical Gaming Keyboard", Description = "RGB Backlit Mechanical Keyboard", ImageUrl = "https://via.placeholder.com/150", Price = 89.99m, StockQuantity = 15 },
            new Product { Id = 2, Name = "Wireless Ergonomic Mouse", Description = "Precision Wireless Optical Mouse", ImageUrl = "https://via.placeholder.com/150", Price = 49.99m, StockQuantity = 20 },
            new Product { Id = 3, Name = "27-inch 144Hz Gaming Monitor", Description = "1080p FHD IPS Gaming Display", ImageUrl = "https://via.placeholder.com/150", Price = 249.99m, StockQuantity = 5 },
            new Product { Id = 4, Name = "RGB Noise-Canceling Headset", Description = "7.1 Surround Sound Headset", ImageUrl = "https://via.placeholder.com/150", Price = 79.99m, StockQuantity = 12 },
            new Product { Id = 5, Name = "USB-C Multi-Port Hub Adapter", Description = "7-in-1 Aluminum USB-C Hub", ImageUrl = "https://via.placeholder.com/150", Price = 29.99m, StockQuantity = 30 },
            new Product { Id = 6, Name = "Streamer USB Condenser Mic", Description = "Cardioid Studio Condenser Microphone", ImageUrl = "https://via.placeholder.com/150", Price = 69.99m, StockQuantity = 0 },
            new Product { Id = 7, Name = "HD 1080p Web Camera", Description = "Wide Angle Webcam with Microphone", ImageUrl = "https://via.placeholder.com/150", Price = 59.99m, StockQuantity = 8 },
            new Product { Id = 8, Name = "XL Gaming Mouse Pad", Description = "Anti-Slip Rubber Base Desk Mat", ImageUrl = "https://via.placeholder.com/150", Price = 19.99m, StockQuantity = 25 }
        };

        // Supports both method names called across controllers
        public List<Product> GetAll() => _products;
        public List<Product> GetAllProducts() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public bool DeductStock(int productId, int quantity)
        {
            var product = GetById(productId);
            if (product != null && product.StockQuantity >= quantity)
            {
                product.StockQuantity -= quantity;
                return true;
            }
            return false;
        }
    }
}
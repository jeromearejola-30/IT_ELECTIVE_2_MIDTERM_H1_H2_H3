using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop for development", Price = 999.99m, ImageUrl = "https://dummyimage.com/300x200/2b3035/ffffff.png&text=Laptop" },
            new Product { Id = 2, Name = "Wireless Mouse", Description = "Ergonomic wireless optical mouse", Price = 25.50m, ImageUrl = "https://dummyimage.com/300x200/2b3035/ffffff.png&text=Wireless+Mouse" },
            new Product { Id = 3, Name = "Mechanical Keyboard", Description = "RGB Backlit mechanical keyboard", Price = 75.00m, ImageUrl = "https://dummyimage.com/300x200/2b3035/ffffff.png&text=Keyboard" },
            new Product { Id = 4, Name = "HD Monitor", Description = "27-inch 1080p IPS display", Price = 180.00m, ImageUrl = "https://dummyimage.com/300x200/2b3035/ffffff.png&text=HD+Monitor" }
        };

        public List<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}
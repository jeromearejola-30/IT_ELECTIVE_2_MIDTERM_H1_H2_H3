using Microsoft.AspNetCore.Mvc;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.DTOs;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Controllers
{
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository;
        private readonly ProductRepository _productRepository;

        public CartController(CartRepository cartRepository, ProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartRepository.GetCart();
            return View(cart);
        }

        // US-02: Add to Cart with DTO & Stock Validation
        [HttpPost]
        public IActionResult AddToCart(AddToCartDTO dto)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Catalog");

            var product = _productRepository.GetById(dto.ProductId) ?? _productRepository.GetProductById(dto.ProductId);
            if (product == null) return RedirectToAction("Index", "Catalog");

            var currentCartItem = _cartRepository.GetCart().Items.FirstOrDefault(i => i.Product.Id == dto.ProductId);
            int currentCartQty = currentCartItem?.Quantity ?? 0;

            // Reject if total requested exceeds available stock (US-02 AC3)
            if (currentCartQty + dto.Quantity > product.StockQuantity)
            {
                TempData["ErrorMessage"] = $"Cannot add {dto.Quantity} item(s). Available stock for {product.Name} is {product.StockQuantity}.";
                return RedirectToAction("Index", "Catalog");
            }

            _cartRepository.AddToCart(product, dto.Quantity);
            return RedirectToAction("Index");
        }

        // US-03: Update Quantity with DTO & Stock Validation
        [HttpPost]
        public IActionResult UpdateQuantity(UpdateCartDTO dto)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            var product = _productRepository.GetById(dto.ProductId) ?? _productRepository.GetProductById(dto.ProductId);
            if (product != null)
            {
                // Reject if updated quantity exceeds static product inventory (US-03 AC3)
                if (dto.Quantity > product.StockQuantity)
                {
                    TempData["ErrorMessage"] = $"Cannot update quantity. Only {product.StockQuantity} available in stock.";
                    return RedirectToAction("Index");
                }

                _cartRepository.UpdateQuantity(dto.ProductId, dto.Quantity);
            }

            return RedirectToAction("Index");
        }

        // US-04: Item Removal
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _cartRepository.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }
    }
}
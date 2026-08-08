using Microsoft.AspNetCore.Mvc;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.DTOs;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly CartRepository _cartRepository;
        private readonly OrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;

        public CheckoutController(CartRepository cartRepository, OrderRepository orderRepository, ProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartRepository.GetCart();
            if (!cart.Items.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty. Please add products before checking out.";
                return RedirectToAction("Index", "Cart");
            }

            ViewBag.Cart = cart;
            return View(new CheckoutDTO());
        }

        [HttpPost]
        public IActionResult Index(CheckoutDTO dto)
        {
            var cart = _cartRepository.GetCart();
            if (!cart.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Cart = cart;
                return View(dto);
            }

            // Verify stock levels before completing transaction
            foreach (var item in cart.Items)
            {
                var product = _productRepository.GetProductById(item.Product.Id) ?? _productRepository.GetById(item.Product.Id);
                if (product == null || product.StockQuantity < item.Quantity)
                {
                    ModelState.AddModelError("", $"Insufficient stock for {item.Product.Name}. Available: {product?.StockQuantity ?? 0}");
                    ViewBag.Cart = cart;
                    return View(dto);
                }
            }

            // Deduct stock permanently from Product Repository
            foreach (var item in cart.Items)
            {
                _productRepository.DeductStock(item.Product.Id, item.Quantity);
            }

            // Create Order / Transaction Record
            var order = new Order
            {
                CustomerName = dto.CustomerName,
                Email = dto.Email,
                ShippingAddress = dto.ShippingAddress,
                PaymentMethod = dto.PaymentMethod,
                Items = cart.Items.Select(i => new OrderItem
                {
                    ProductId = i.Product.Id,
                    ProductName = i.Product.Name,
                    Price = i.Product.Price,
                    Quantity = i.Quantity
                }).ToList()
            };

            _orderRepository.SaveOrder(order);

            // Clear shopping cart
            _cartRepository.Clear();

            return RedirectToAction("Confirmation", new { orderId = order.OrderId });
        }

        [HttpGet]
        public IActionResult Confirmation(string orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return RedirectToAction("Index", "Catalog");
            }

            return View(order);
        }

        // US-06: Transaction History
        [HttpGet]
        public IActionResult History()
        {
            var transactions = _orderRepository.GetAllOrders();
            return View(transactions);
        }
    }
}
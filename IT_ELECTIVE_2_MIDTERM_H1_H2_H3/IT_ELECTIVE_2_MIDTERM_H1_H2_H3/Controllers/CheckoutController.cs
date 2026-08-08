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

        public CheckoutController(CartRepository cartRepository, OrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartRepository.GetCart();
            if (!cart.Items.Any())
            {
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
            cart.Items.Clear();

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
    }
}
using Microsoft.AspNetCore.Mvc;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.DTOs;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Controllers
{
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository;

        public CartController(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IActionResult Index()
        {
            var cart = _cartRepository.GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(UpdateCartDTO dto)
        {
            _cartRepository.UpdateQuantity(dto.ProductId, dto.Quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveItem(int productId)
        {
            _cartRepository.RemoveItem(productId);
            return RedirectToAction("Index");
        }
    }
}
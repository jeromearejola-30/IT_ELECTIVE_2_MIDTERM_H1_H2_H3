using Microsoft.AspNetCore.Mvc;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.DTOs;
using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly CartRepository _cartRepository;

        public CatalogController(ProductRepository productRepository, CartRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(AddToCartDTO dto)
        {
            var product = _productRepository.GetById(dto.ProductId);
            if (product != null)
            {
                _cartRepository.AddItem(product, dto.Quantity);
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
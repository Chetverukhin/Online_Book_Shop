using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IRepository<Product> _productsRepository;

        public CartController(ICartsRepository cartsRepository, IRepository<Product> productsRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartDb = _cartsRepository.GetById(userId);
            var userCart = Mapping.ToCartViewModel(cartDb);

            return View(userCart);
        }

        [HttpPost]
        public IActionResult AddBookCart(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = _productsRepository.GetById(bookId);
            var existCart = _cartsRepository.GetById(userId);

            existCart.CartProducts ??= new List<CartProduct>();

            if (!existCart.CartProducts.Any(cart => cart.Product.Id.Equals(product.Id)))
            {
                var newCartProduct = new CartProduct()
                {
                    Product = product,
                    Quantity = 1
                };

                existCart.CartProducts.Add(newCartProduct);
            }
            else
            {
                existCart.CartProducts.First(cart => cart.Product.Id.Equals(product.Id)).Quantity++;
            }

            _cartsRepository.Add(existCart);
            _cartsRepository.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public IActionResult DelBookCart(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = _productsRepository.GetById(bookId);
            var existCart = _cartsRepository.GetById(userId);

            if (!existCart.CartProducts.Any(cart => cart.Product.Id.Equals(product.Id)))
            {
                return RedirectToAction("Index", "Cart");
            }

            var cartProduct = existCart.CartProducts.First(cart => cart.Product.Id.Equals(product.Id));

            if (cartProduct.Quantity <= 1)
            {
                existCart.CartProducts.Remove(cartProduct);
            }
            else
            {
                existCart.CartProducts.First(cart => cart.Product.Id.Equals(product.Id)).Quantity--;
            }

            _cartsRepository.Update(existCart);
            _cartsRepository.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult ClearCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _cartsRepository.Delete(userId);
            _cartsRepository.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }
    }
}

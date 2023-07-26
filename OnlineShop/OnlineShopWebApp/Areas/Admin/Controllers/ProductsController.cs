using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constant.AdminRoleName)]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _productsRepository;

        public ProductsController(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = Mapping.ToProductViewModelList(_productsRepository.GetAll());

            return View(products);
        }

        public IActionResult EditProduct(int bookId)
        {
            var product = Mapping.ToProductViewModel(_productsRepository.GetById(bookId));

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product editProduct)
        {
            _productsRepository.Update(editProduct);
            _productsRepository.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public IActionResult RemoveProduct(int bookId)
        {
            _productsRepository.Delete(bookId);
            _productsRepository.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public IActionResult AddProduct()
        {
            var newProduct = new ProductViewModel();

            return View(newProduct);
        }

        [HttpPost]
        public IActionResult AddProduct(Product newProduct)
        {
            _productsRepository.Add(newProduct);
            _productsRepository.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Product> _productsRepository;

        public HomeController(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = Mapping.ToProductViewModelList(_productsRepository.GetAll());

            return View(products);
        }

        [HttpPost]
        public IActionResult Index(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return RedirectToAction("Index", "Home");
            }

            var pattern = searchText.ToLower();
            var filteredListByName = _productsRepository.GetFilteredCollection(product => product.Name.ToLower().Contains(pattern));
            var filteredProducts = Mapping.ToProductViewModelList(filteredListByName);

            return View(filteredProducts);
        }
    }
}

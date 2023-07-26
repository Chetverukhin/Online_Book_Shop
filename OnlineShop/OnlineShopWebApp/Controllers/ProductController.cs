using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly HttpClient _client = new();

        public ProductController(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> Index(int bookId)
        {
            var product = Mapping.ToProductViewModel(_productsRepository.GetById(bookId));
            product.FeedBacks = await GetFeedBacksByProductId(bookId);

            return View(product);
        }

        public async Task<List<FeedBackViewModel>> GetFeedBacksByProductId(int productId)
        {
            var feedBack = new List<FeedBackViewModel>();

            try
            {
                var requestUri = $"https://localhost:7274/FeedBack/GetFeedBacksByProductId?productId={productId}";
                var response = await _client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    feedBack = JsonConvert.DeserializeObject<List<FeedBackViewModel>>(content);
                }
            }
            catch
            {

            }

            return feedBack;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddFeedBack(int bookId)
        {
            var model = new ProductFeedBackModel
            {
                FeedBack = new FeedBackViewModel
                {
                    ProductId = bookId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                },

                Product = Mapping.ToProductViewModel(_productsRepository.GetById(bookId))
            };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddFeedBack(FeedBackViewModel feedBack)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("https://localhost:7274/FeedBack/AddNewFeedBack", feedBack);
            }
            catch
            {

            }            

            return RedirectToAction("Index", "Product", new { bookId = feedBack.ProductId });
        }
    }
}

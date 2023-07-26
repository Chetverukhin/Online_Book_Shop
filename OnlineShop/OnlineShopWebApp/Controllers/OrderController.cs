using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;
using OnlineShopWebApp.Models;
using System.Security.Claims;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IRepository<Order> _ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IRepository<Order> ordersRepository)
        {
            _cartsRepository = cartsRepository;
            _ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var model = new OrderDataViewModel()
            {
                Cart = Mapping.ToCartViewModel(_cartsRepository.GetById(User.FindFirstValue(ClaimTypes.NameIdentifier))),
                OrderInfo = new OrderInfoViewModel()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(OrderInfo orderInfo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (orderInfo.Name == orderInfo.LastName)
            {
                ModelState.AddModelError(string.Empty, "Имя и  Фамилия не должны совпадать");
            }

            if (!ModelState.IsValid)
            {
                var model = new OrderDataViewModel()
                {
                    Cart = Mapping.ToCartViewModel(_cartsRepository.GetById(userId)),
                    OrderInfo = Mapping.ToOrderInfoViewModel(orderInfo)
                };

                return View(model);
            }

            var newOrder = new Order()
            {
                Products = _cartsRepository.GetById(userId).CartProducts,
                UserId = userId,
                Info = orderInfo
            };

            _ordersRepository.Add(newOrder);
            _ordersRepository.SaveChanges();

            _cartsRepository.Delete(userId);
            _cartsRepository.SaveChanges();

            return RedirectToAction("Accept", "Order");
        }

        public IActionResult Accept()
        {
            return View();
        }
    }
}

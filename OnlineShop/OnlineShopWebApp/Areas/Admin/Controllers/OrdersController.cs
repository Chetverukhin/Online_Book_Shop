using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constant.AdminRoleName)]
    public class OrdersController : Controller
    {
        private readonly IRepository<Order> _ordersRepository;

        public OrdersController(IRepository<Order> ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var ordersDb = _ordersRepository.GetAll();

            var orders = Mapping.ToOrderViewModelList(ordersDb);

            return View(orders);
        }
        public IActionResult EditOrder(int orderId)
        {
            var orderDb = _ordersRepository.GetById(orderId);
            var order = Mapping.ToOrderViewModel(orderDb);

            return View(order);
        }

        [HttpPost]
        public IActionResult EditOrder(int orderId, EnumOrderStatuses status)
        {
            var editOrder = _ordersRepository.GetById(orderId);
            editOrder.Status = status;

            _ordersRepository.SaveChanges();

            return RedirectToAction("Index", "Orders");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Services;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository _cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke(string userId)
        {
            var cartDb = _cartsRepository.GetById(userId);
            var userCart = Mapping.ToCartViewModel(cartDb);
            var productsCount = userCart.CartProducts.Sum(item => item.Quantity);

            return View("Cart", productsCount);
        }
    }
}

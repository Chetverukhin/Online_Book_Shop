using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;

namespace OnlineShopWebApp.Views.Shared.Components.CardItem
{
    public class CardItemViewComponent : ViewComponent
    {
        private readonly IRepository<Product> _productsRepository;

        public CardItemViewComponent(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IViewComponentResult Invoke(int bookId)
        {
            var product = Mapping.ToProductViewModel(_productsRepository.GetById(bookId));

            return View("CardItem", product);
        }
    }
}

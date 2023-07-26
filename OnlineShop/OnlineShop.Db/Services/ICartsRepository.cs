using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db.Services
{
    public interface ICartsRepository
    {
        void Add(Cart newCart);
        Cart GetById(string userId);
        void Update(Cart newCart);
        void Delete(string userId);
        IEnumerable<Cart> GetAll();
        void SaveChanges();
    }
}

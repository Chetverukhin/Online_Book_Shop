using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Services
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DataBaseContext _context;

        public CartsDbRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Add(Cart newCart)
        {
            if (_context.Carts.Any(cart => cart.UserId.Equals(newCart.UserId)))
            {
                Update(newCart);
                return;
            }

            _context.Carts.Add(newCart);
        }

        public Cart GetById(string userId)
        {
            var userCart = new Cart() { UserId = userId };

            return _context.Carts.Any(cart => cart.UserId.Equals(userId)) ?
                _context.Carts.Include(cart => cart.CartProducts)
                    .ThenInclude(cart => cart.Product)
                    .First(cart => cart.UserId.Equals(userId)) : userCart;
        }

        public void Update(Cart newCart)
        {
            if (!_context.Carts.Any(cart => cart.UserId.Equals(newCart.UserId))) return;

            _context.Carts.Update(newCart);
        }

        public void Delete(string userId)
        {
            var existCart = GetById(userId);
            _context.Carts.Remove(existCart);
        }

        public IEnumerable<Cart> GetAll()
        {
            return _context.Carts.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

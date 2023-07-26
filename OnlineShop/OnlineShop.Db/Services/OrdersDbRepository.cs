using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Services
{
    public class OrdersDbRepository : IRepository<Order>
    {
        private readonly DataBaseContext _context;

        public OrdersDbRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Add(Order newOrder)
        {
            if (_context.Orders.Any(order => order.Id.Equals(newOrder.Id)))
            {
                Update(newOrder);
                return;
            }

            _context.Orders.Add(newOrder);

        }

        public Order GetById(int orderId)
        {
            var userOrder = new Order() { Id = orderId };

            return _context.Orders.Any(order => order.Id.Equals(orderId)) ?
                   GetAll().First(order => order.Id.Equals(orderId)) : userOrder;
        }

        public Order FindItem(Func<Order, bool> predicate)
        {
            return _context.Orders.FirstOrDefault(predicate);
        }

        public void Update(Order newOrder)
        {
            if (!_context.Orders.Any(order => order.Id.Equals(newOrder.Id))) return;

            _context.Orders.Update(newOrder);
        }

        public void Delete(int orderId)
        {
            var existOrder = GetById(orderId);
            _context.Orders.Remove(existOrder);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(order => order.Products)
                   .ThenInclude(order => order.Product)
                   .Include(order => order.Info);
        }

        public IEnumerable<Order> GetFilteredCollection(Func<Order, bool> predicate)
        {
            var result = new List<Order>();

            return predicate == null ? result : _context.Orders.Where(predicate);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

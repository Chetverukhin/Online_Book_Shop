using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Services
{
    public class ProductsDbRepository : IRepository<Product>
    {
        private readonly DataBaseContext _context;

        public ProductsDbRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Add(Product newProduct)
        {
            if (_context.Products.Contains(newProduct))
            {
                Update(newProduct);
                return;
            }
            _context.Products.Add(newProduct);
        }

        public Product GetById(int id)
        {
            return _context.Products.First(product => product.Id.Equals(id));
        }

        public Product FindItem(Func<Product, bool> predicate)
        {
            return _context.Products.FirstOrDefault(predicate);
        }

        public void Update(Product product)
        {
            if (!_context.Products.Contains(product)) return;

            _context.Products.Update(product);
        }

        public void Delete(int id)
        {
            var product = new Product { Id = id };

            if (_context.Products.Contains(product))
            {
                _context.Products.Remove(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetFilteredCollection(Func<Product, bool> predicate)
        {
            var result = new List<Product>();

            return predicate == null ? result : _context.Products.Where(predicate);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
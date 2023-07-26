using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Services
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        T GetById(int id);
        T FindItem(Func<T, bool> predicate);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetFilteredCollection(Func<T, bool> predicate);
        void SaveChanges();
    }
}

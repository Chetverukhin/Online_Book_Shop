using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShop.Db
{
    public sealed class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("DB_Library.json"));
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}

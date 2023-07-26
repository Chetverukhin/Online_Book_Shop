using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public List<CartProduct> CartProducts { get; set; }

        public Product()
        {
            CartProducts = new List<CartProduct>();
        }
    }
}
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartProduct> CartProducts { get; set; }

        public Cart()
        {
            CartProducts = new List<CartProduct>();
        }
    }
}
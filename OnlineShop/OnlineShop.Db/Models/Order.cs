using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CartProduct> Products { get; set; }
        public string UserId { get; set; }
        public EnumOrderStatuses Status { get; set; }
        public OrderInfo Info { get; set; }

        public Order()
        {
            CreatedDate = DateTime.Now;
            Status = EnumOrderStatuses.Created;
        }
    }
}

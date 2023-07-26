using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel : IEquatable<OrderViewModel>
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CartProductViewModel> Products { get; set; }
        public string UserId { get; set; }
        public EnumOrderStatuses Status { get; set; }
        public OrderInfoViewModel Info { get; set; }

        public bool Equals(OrderViewModel other)
        {
            return other != null && Id.Equals(other.Id);
        }
    }
}

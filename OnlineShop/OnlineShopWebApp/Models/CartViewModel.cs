using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartViewModel : IEquatable<CartViewModel>
    {
        public List<CartProductViewModel> CartProducts { get; set; }
        public string UserId { get; set; }
        public decimal SubTotal => CartProducts.Sum(item => item.TotalPrice);

        public CartViewModel(string userId)
        {
            CartProducts = new List<CartProductViewModel>();
            UserId = userId;
        }

        public void AddItem(ProductViewModel product)
        {
            var newItem = new CartProductViewModel(product);

            if (CartProducts.Contains(newItem))
            {
                CartProducts.First(item => item.Equals(newItem)).Quantity++;
                return;
            }

            newItem.Quantity = 1;
            CartProducts.Add(newItem);
        }

        public void DelItem(ProductViewModel product)
        {
            var delBook = new CartProductViewModel(product);

            if (!CartProducts.Contains(delBook)) return;

            var item = CartProducts.First(item => item.Equals(delBook));

            if (item.Quantity <= 1)
            {
                RemoveItem(product);
                return;
            }

            item.Quantity--;
        }

        public void SetItemsQuantity(ProductViewModel product, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(product);
            }

            var updateItem = new CartProductViewModel(product);

            if (!CartProducts.Contains(updateItem)) return;
            CartProducts.First(item => item.Equals(updateItem)).Quantity = quantity;
        }

        public void RemoveItem(ProductViewModel product)
        {
            var removedItem = new CartProductViewModel(product);
            CartProducts.Remove(removedItem);
        }

        public void Clear()
        {
            CartProducts.Clear();
        }

        public bool Equals(CartViewModel other)
        {
            return other != null && UserId == other.UserId;
        }
    }
}

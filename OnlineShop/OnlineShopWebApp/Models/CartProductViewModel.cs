using System;

namespace OnlineShopWebApp.Models
{
    public class CartProductViewModel : IEquatable<CartProductViewModel>
    {
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Cost * Quantity;

        public CartProductViewModel(ProductViewModel product)
        {
            Product = product;
        }

        public bool Equals(CartProductViewModel other)
        {
            return other != null && Product.Id == other.Product.Id;
        }
    }
}

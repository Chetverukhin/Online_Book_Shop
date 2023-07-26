using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public static class Mapping
    {
        //MAPPING PRODUCT

        public static List<ProductViewModel> ToProductViewModelList(IEnumerable<Product> products)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductViewModel>());
            var mapper = new Mapper(config);
            var result = mapper.Map<List<ProductViewModel>>(products).ToList();

            return result;
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductViewModel>());
            var mapper = new Mapper(config);
            var result = mapper.Map<ProductViewModel>(product);

            return result;
        }

        //MAPPING CART

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            return new CartViewModel(cart.UserId)
            {
                CartProducts = ToCartProductViewModelList(cart.CartProducts)
            };
        }

        public static List<CartProductViewModel> ToCartProductViewModelList(List<CartProduct> cartProducts)
        {
            cartProducts ??= new List<CartProduct>();

            return (from cartProduct in cartProducts
                    let product = ToProductViewModel(cartProduct.Product)
                    select new CartProductViewModel(product)
                    {
                        Quantity = cartProduct.Quantity,
                    }).ToList();
        }

        //MAPPING ORDER

        public static List<OrderViewModel> ToOrderViewModelList(IEnumerable<Order> orders)
        {
            orders ??= new List<Order>();

            return orders.Select(ToOrderViewModel).ToList();
        }

        public static OrderInfoViewModel ToOrderInfoViewModel(OrderInfo orderInfo)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderInfo, OrderInfoViewModel>());
            var mapper = new Mapper(config);
            var result = mapper.Map<OrderInfoViewModel>(orderInfo);

            return result;
        }

        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                Products = ToCartProductViewModelList(order.Products),
                UserId = order.UserId,
                Status = order.Status,
                Info = ToOrderInfoViewModel(order.Info)
            };
        }

        //MAPPING USER

        public static UserViewModel ToUserViewModel(User user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserViewModel>());
            var mapper = new Mapper(config);
            var result = mapper.Map<UserViewModel>(user);

            return result;
        }

        //MAPPING ROLE

        public static RoleViewModel ToRoleViewModel(IdentityRole role)
        {
            var result = new RoleViewModel
            {
                Id = role.Id,
                UserId = string.Empty,
                Name = role.Name,
                CurrentName = role.Name,
                Description = string.Empty
            };
            return result;
        }
    }
}

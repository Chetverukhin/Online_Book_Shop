using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel : IEquatable<ProductViewModel>
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }

        [Required(ErrorMessage = "Не указано Название товара")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Введите корректное Название товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана Цена товара")]
        [Range(typeof(decimal), "5,0", "100000,0", ErrorMessage = "Наименьшая цена - 5 рублей")]
        public decimal Cost { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Введите корректный Жанр")]
        public string Genre { get; set; }

        [Range(50, 2000, ErrorMessage = "Ведите корректное количество страниц")]
        public int Pages { get; set; }

        [Range(1900, 2023, ErrorMessage = "Введите корректный год")]
        public int Year { get; set; }

        [StringLength(250, MinimumLength = 10, ErrorMessage = "Введите корректное описание")]
        public string Description { get; set; }

        [StringLength(250, MinimumLength = 10, ErrorMessage = "Введите корректное описание")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Не указано Имя Автора")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Введите корректное Название товаоа")]

        public string Author { get; set; }

        [RegularExpression("^(?=(?:\\D*\\d){10}(?:(?:\\D*\\d){3})?$)[\\d-]+$", ErrorMessage = "Введите корректный номер ISBN")]
        public string Isbn { get; set; }

        public List<FeedBackViewModel> FeedBacks { get; set; }

        public ProductViewModel()
        {
            const string defaultBookCover = "https://paolotaticchi.com/wp-content/uploads/2022/09/book-big.webp";
            ImageLink ??= defaultBookCover;
        }

        public bool Equals(ProductViewModel other)
        {
            return other != null && Id == other.Id;
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class FeedBackViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Введите корректный отзыв")]
        public string Text { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Рейтинг должен быть от 0 до 5")]
        public int Grade { get; set; }
    }
}

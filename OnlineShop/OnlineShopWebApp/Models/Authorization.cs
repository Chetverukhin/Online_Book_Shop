using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Authorization
    {
        [Required(ErrorMessage = "Не указан Логин")]
        [RegularExpression("[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", ErrorMessage = "Введите корректный адрес example@email.com")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Пароль должен быть от 7 до 20 символов")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class OrderInfoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано Имя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Введите корректное имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана Фамилия")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Введите корректную Фамилию")]
        public string LastName { get; set; }

        [RegularExpression("[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", ErrorMessage = "Введите корректный адрес example@email.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите свой адрес доставки.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Введите корректный адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Требуется почтовый индекс")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Введите корректный почтовый индекс")]
        public string PostIndex { get; set; }
    }
}

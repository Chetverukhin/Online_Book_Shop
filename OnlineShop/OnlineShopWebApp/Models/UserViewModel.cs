using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Не указано Имя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Введите корректное имя")]
        public string UserName { get; set; }

        [StringLength(30, MinimumLength = 2, ErrorMessage = "Введите корректную Фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан адрес почты")]
        [RegularExpression("[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", ErrorMessage = "Введите корректный адрес example@email.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан Номер телефона")]
        [RegularExpression("^\\+?[78][-\\(]?\\d{3}\\)?-?\\d{3}-?\\d{2}-?\\d{2}$", ErrorMessage = "Введите корректный Номер Телефона")]
        public string PhoneNumber { get; set; }

        [StringLength(30, MinimumLength = 2, ErrorMessage = "Введите корректное Отчетство")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }
    }
}
